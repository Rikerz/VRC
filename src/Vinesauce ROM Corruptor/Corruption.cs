/* 
 * Copyright (C) 2013 Ryan Sammon.
 * 
 * This file is part of the Vinesauce ROM Corruptor.
 * 
 * The Vinesauce ROM Corruptor is free software: you can redistribute
 * it and/or modify it under the terms of the GNU General Public 
 * License as published by the Free Software Foundation, either 
 * version 3 of the License, or (at your option) any later version.
 * 
 * The Vinesauce ROM Corruptor is distributed in the hope that it
 * will be useful, but WITHOUT ANY WARRANTY; without even the implied
 * warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  
 * See the GNU General Public License for more details.
 * 
 * You should have received a copy of the GNU General Public License
 * along with the Vinesauce ROM Corruptor.  If not, see 
 * <http://www.gnu.org/licenses/>.
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Vinesauce_ROM_Corruptor
{
    static class Corruption
    {
        public enum ByteCorruptionOptions
        {
            AddXToByte,
            ShiftRightXBytes,
            ReplaceByteXwithY
        }

        static private List<byte> NESCPUJamProtection_Avoid = new List<byte>() { 0x48, 0x08, 0x68, 0x28, 0x78, 0x00, 0x02, 0x12, 0x22, 0x32, 0x42, 0x52, 0x62, 0x72, 0x92, 0xB2, 0xD2, 0xF2 };
        static private List<byte> NESCPUJamProtection_Protect_1 = new List<byte>() { 0x48, 0x08, 0x68, 0x28, 0x78, 0x40, 0x60, 0x00, 0x90, 0xB0, 0xF0, 0x30, 0xD0, 0x10, 0x50, 0x70, 0x4C, 0x6C, 0x20 };
        static private List<byte> NESCPUJamProtection_Protect_2 = new List<byte>() { 0x90, 0xB0, 0xF0, 0x30, 0xD0, 0x10, 0x50, 0x70, 0x4C, 0x6C, 0x20 };
        static private List<byte> NESCPUJamProtection_Protect_3 = new List<byte>() { 0x4C, 0x6C, 0x20 };

        public static byte[] Run
            (byte[] ROM, bool ByteCorruptionEnable, long StartByte, long EndByte, ByteCorruptionOptions ByteCorruptionOption,
            uint EveryNthByte, int AddXtoByte, int ShiftRightXBytes, byte ReplaceByteXwithYByteX, byte ReplaceByteXwithYByteY, bool EnableNESCPUJamProtection,
            bool TextReplacementEnable, bool TextUseByteCorruptionRange, string RawTextToReplace, string RawReplaceWith, string RawAnchorWords,
            bool ColorReplacementEnable, bool ColorUseByteCorruptionRange, string RawColorsToReplace, string RawReplaceWithColors)
        {
            // Areas to not corrupt.
            List<long[]> ProtectedRegions = new List<long[]>();

            // Delimeter for text sections.
            char[] Delimeter = new char[1] { '|' };

            // Do text replacement if desired.
            if (TextReplacementEnable)
            {
                // Translation dictionary.
                Dictionary<char, byte> TranslationDictionary = new Dictionary<char, byte>();

                // Read in the text and its replacement.
                string[] TextToReplace = RawTextToReplace.Split(Delimeter, StringSplitOptions.RemoveEmptyEntries);
                string[] ReplaceWith = RawReplaceWith.Split(Delimeter, StringSplitOptions.RemoveEmptyEntries);

                // Make sure they have equal length.
                if (TextToReplace.Length != ReplaceWith.Length)
                {
                    MessageBox.Show("Number of text sections to replace does not match number of replacements.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return null;
                }

                // Create relative offset arrays of the anchors.
                string[] Anchors = RawAnchorWords.Split(Delimeter, StringSplitOptions.RemoveEmptyEntries);
                int[][] RelativeAnchors = new int[Anchors.Length][];
                for (int i = 0; i < Anchors.Length; i++)
                {
                    RelativeAnchors[i] = new int[Anchors[i].Length];
                    for (int j = 0; j < Anchors[i].Length; j++)
                    {
                        RelativeAnchors[i][j] = Anchors[i][j] - Anchors[i][0];
                    }
                }

                // Look for the anchors.
                for (int i = 0; i < RelativeAnchors.Length; i++)
                {
                    // Position in ROM.
                    long j = 0;

                    // Scan the entire ROM.
                    while (j < ROM.LongLength)
                    {
                        // If a match has been found.
                        bool Match = true;

                        // Look for the relative values.
                        for (int k = 0; k < RelativeAnchors[i].Length; k++)
                        {
                            // Make sure its in range.
                            if (j + k < ROM.LongLength)
                            {
                                // Ignore non-letter characters for matching purposes.
                                if (!Char.IsLetter(Anchors[i][k]))
                                {
                                    continue;
                                }

                                // Check if the relative value doesn't match.
                                if ((ROM[j + k] - ROM[j]) != RelativeAnchors[i][k])
                                {
                                    // It doesn't, break.
                                    Match = false;
                                    break;
                                }
                            }
                            else
                            {
                                // Out of range before matching.
                                Match = false;
                                break;
                            }
                        }

                        // If a match was found, update the dictionary.
                        if (Match)
                        {
                            int k = 0;
                            for (k = 0; k < Anchors[i].Length; k++)
                            {
                                if (!TranslationDictionary.ContainsKey(Anchors[i][k]))
                                {
                                    TranslationDictionary.Add(Anchors[i][k], ROM[j + k]);
                                }
                            }

                            // Move ahead to the correct location in the ROM.
                            j = j + k + 1;
                        }
                        else
                        {
                            // Move ahead one byte.
                            j = j + 1;
                        }
                    }
                }

                // Calculate the offset to translate unknown text, assuming ASCII structure.
                int ASCIIOffset = 0;
                if (TranslationDictionary.Count > 0)
                {
                    ASCIIOffset = TranslationDictionary.First().Value - TranslationDictionary.First().Key;
                }

                // Create arrays of the text to be replaced in ROM format.
                byte[][] ByteTextToReplace = new byte[TextToReplace.Length][];
                for (int i = 0; i < TextToReplace.Length; i++)
                {
                    ByteTextToReplace[i] = new byte[TextToReplace[i].Length];
                    for (int j = 0; j < TextToReplace[i].Length; j++)
                    {
                        if (TranslationDictionary.ContainsKey(TextToReplace[i][j]))
                        {
                            ByteTextToReplace[i][j] = TranslationDictionary[TextToReplace[i][j]];
                        }
                        else
                        {
                            int ASCIITranslated = TextToReplace[i][j] + ASCIIOffset;
                            if (ASCIITranslated >= Byte.MinValue && ASCIITranslated <= Byte.MaxValue)
                            {
                                ByteTextToReplace[i][j] = (byte)(ASCIITranslated);
                            }
                            else
                            {
                                // Could not translate.
                                ByteTextToReplace[i][j] = (byte)(TextToReplace[i][j]);
                            }
                        }
                    }
                }

                // Create arrays of the replacement text in ROM format.
                byte[][] ByteReplaceWith = new byte[ReplaceWith.Length][];
                for (int i = 0; i < ReplaceWith.Length; i++)
                {
                    ByteReplaceWith[i] = new byte[ReplaceWith[i].Length];
                    for (int j = 0; j < ReplaceWith[i].Length; j++)
                    {
                        if (TranslationDictionary.ContainsKey(ReplaceWith[i][j]))
                        {
                            ByteReplaceWith[i][j] = TranslationDictionary[ReplaceWith[i][j]];
                        }
                        else
                        {
                            int ASCIITranslated = ReplaceWith[i][j] + ASCIIOffset;
                            if (ASCIITranslated >= Byte.MinValue && ASCIITranslated <= Byte.MaxValue)
                            {
                                ByteReplaceWith[i][j] = (byte)(ASCIITranslated);
                            }
                            else
                            {
                                // Could not translate.
                                ByteReplaceWith[i][j] = (byte)(ReplaceWith[i][j]);
                            }
                        }
                    }
                }

                // Area of ROM to consider.
                long TextReplacementStartByte = 0;
                long TextReplacementEndByte = ROM.LongLength - 1;

                // Change area if using the byte corruption range.
                if (TextUseByteCorruptionRange)
                {
                    TextReplacementStartByte = StartByte;
                    TextReplacementEndByte = EndByte;
                }

                // Look for the text to replace.
                for (int i = 0; i < ByteTextToReplace.Length; i++)
                {
                    // Position in ROM.
                    long j = TextReplacementStartByte;

                    // Scan the entire ROM.
                    while (j <= TextReplacementEndByte)
                    {
                        // If a match has been found.
                        bool Match = true;

                        // Look for the text.
                        for (int k = 0; k < ByteTextToReplace[i].Length; k++)
                        {
                            // Make sure its in range.
                            if (j + k <= TextReplacementEndByte)
                            {
                                // Ignore non-letter characters for matching purposes.
                                if (!Char.IsLetter(TextToReplace[i][k]))
                                {
                                    continue;
                                }

                                // Check if the relative value doesn't match.
                                if (ROM[j + k] != ByteTextToReplace[i][k])
                                {
                                    // It doesn't, break.
                                    Match = false;
                                    break;
                                }
                            }
                            else
                            {
                                // Out of range before matching.
                                Match = false;
                                break;
                            }
                        }

                        // If the entire string matched, replace it.
                        if (Match)
                        {
                            // If the area is protected.
                            bool Protected = false;

                            // Length of the replacement.
                            int k = ByteReplaceWith[i].Length - 1;

                            // Check if the area is protected.
                            foreach (long[] ProtectedRegion in ProtectedRegions)
                            {
                                if ((j >= ProtectedRegion[0] && j <= ProtectedRegion[1]) || (j + k >= ProtectedRegion[0] && j + k <= ProtectedRegion[1]) || (j < ProtectedRegion[0] && j + k > ProtectedRegion[1]))
                                {
                                    // Yes, its protected.
                                    Protected = true;
                                    break;
                                }
                            }

                            // If not protected, replace the text.
                            if (!Protected)
                            {
                                for (k = 0; k < ByteReplaceWith[i].Length; k++)
                                {
                                    ROM[j + k] = ByteReplaceWith[i][k];
                                }

                                // Protect the inserted text.
                                ProtectedRegions.Add(new long[2] { j, j + k });
                            }

                            // Move ahead to the correct location in the ROM.
                            j = j + k + 1;
                        }
                        else
                        {
                            // Move ahead one byte.
                            j = j + 1;
                        }
                    }
                }
            }

            // Do color replacement if desired.
            if (ColorReplacementEnable)
            {
                // Read in the text and its replacement.
                string[] ColorsToReplace = RawColorsToReplace.Split(Delimeter, StringSplitOptions.RemoveEmptyEntries);
                string[] ColorsReplaceWith = RawReplaceWithColors.Split(Delimeter, StringSplitOptions.RemoveEmptyEntries);

                // Make sure they have equal length.
                if (ColorsToReplace.Length != ColorsReplaceWith.Length)
                {
                    MessageBox.Show("Number of colors to replace does not match number of replacements.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return null;
                }

                // Convert the strings.
                byte[] ColorsToReplaceBytes = new byte[ColorsToReplace.Length];
                byte[] ColorsReplaceWithBytes = new byte[ColorsReplaceWith.Length];
                for (int i = 0; i < ColorsToReplace.Length; i++)
                {
                    try
                    {
                        byte Converted = Convert.ToByte(ColorsToReplace[i], 16);
                        ColorsToReplaceBytes[i] = Converted;
                    }
                    catch
                    {
                        MessageBox.Show("Invalid color to replace.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return null;
                    }
                }
                for (int i = 0; i < ColorsReplaceWithBytes.Length; i++)
                {
                    try
                    {
                        byte Converted = Convert.ToByte(ColorsReplaceWith[i], 16);
                        ColorsReplaceWithBytes[i] = Converted;
                    }
                    catch
                    {
                        MessageBox.Show("Invalid color replacement.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return null;
                    }
                }

                // Area of ROM to consider.
                long ColorReplacementStartByte = 0;
                long ColorReplacementEndByte = ROM.LongLength - 1;

                // Change area if using the byte corruption range.
                if (ColorUseByteCorruptionRange)
                {
                    ColorReplacementStartByte = StartByte;
                    ColorReplacementEndByte = EndByte;
                }

                // Position in ROM.
                long j = ColorReplacementStartByte;

                // Scan the entire ROM.
                while (j <= ColorReplacementEndByte)
                {
                    // If a palette has been found.
                    bool Palette = true;

                    // Look for a palette.
                    for (int k = 0; k < 4; k++)
                    {
                        // Make sure its in range.
                        if (j + k <= ColorReplacementEndByte)
                        {
                            // Check if value exceeds the maximum valid color value.
                            if (ROM[j + k] > 0x3F)
                            {
                                // It does, break.
                                Palette = false;
                                break;
                            }
                        }
                        else
                        {
                            // Out of range before matching.
                            Palette = false;
                            break;
                        }
                    }

                    // If a possible palette was found, do color replacement.
                    if (Palette)
                    {
                        for (int i = 0; i < ColorsToReplaceBytes.Length; i++)
                        {
                            for (int k = 0; k < 4; k++)
                            {
                                if (ROM[j + k] == ColorsToReplaceBytes[i])
                                {
                                    // If the byte is protected.
                                    bool Protected = false;

                                    // Check if the byte is protected.
                                    foreach (long[] ProtectedRegion in ProtectedRegions)
                                    {
                                        if (j + k >= ProtectedRegion[0] && j + k <= ProtectedRegion[1])
                                        {
                                            // Yes, its protected.
                                            Protected = true;
                                            break;
                                        }
                                    }

                                    // If its not protected, do the replacement.
                                    if (!Protected)
                                    {
                                        ROM[j + k] = ColorsReplaceWithBytes[i];
                                        ProtectedRegions.Add(new long[2] { j + k, j + k });
                                    }
                                }
                            }
                        }

                        // Move ahead to the correct location in the ROM.
                        j = j + 4;
                    }
                    else
                    {
                        // Move ahead one byte.
                        j = j + 1;
                    }
                }
            }

            // Do byte corruption if desired.
            if (ByteCorruptionEnable)
            {
                if (ByteCorruptionOption == ByteCorruptionOptions.AddXToByte && AddXtoByte != 0)
                {
                    for (long i = StartByte + EveryNthByte; i <= EndByte; i = i + EveryNthByte)
                    {
                        // If the byte is protected.
                        bool Protected = false;

                        // Check if the byte is protected.
                        foreach (long[] ProtectedRegion in ProtectedRegions)
                        {
                            if (i >= ProtectedRegion[0] && i <= ProtectedRegion[1])
                            {
                                // Yes, its protected.
                                Protected = true;
                                break;
                            }
                        }

                        // Do NES CPU jam protection if desired.
                        if (EnableNESCPUJamProtection)
                        {
                            if (!Protected && i >= 2)
                            {
                                if (NESCPUJamProtection_Avoid.Contains((byte)((ROM[i] + AddXtoByte) % (Byte.MaxValue + 1)))
                                    || NESCPUJamProtection_Protect_1.Contains(ROM[i])
                                    || NESCPUJamProtection_Protect_2.Contains(ROM[i - 1])
                                    || NESCPUJamProtection_Protect_3.Contains(ROM[i - 2]))
                                {
                                    Protected = true;
                                }
                            }
                        }

                        // If the byte is not protected, corrupt it.
                        if (!Protected)
                        {
                            int NewValue = (ROM[i] + AddXtoByte) % (Byte.MaxValue + 1);
                            ROM[i] = (byte)NewValue;
                        }
                    }
                }
                else if (ByteCorruptionOption == ByteCorruptionOptions.ShiftRightXBytes && ShiftRightXBytes != 0)
                {
                    for (long i = StartByte + EveryNthByte; i <= EndByte; i = i + EveryNthByte)
                    {
                        long j = i + ShiftRightXBytes;

                        if (j >= StartByte && j <= EndByte)
                        {
                            // If the byte is protected.
                            bool Protected = false;

                            // Check if the byte is protected.
                            foreach (long[] ProtectedRegion in ProtectedRegions)
                            {
                                if (j >= ProtectedRegion[0] && j <= ProtectedRegion[1])
                                {
                                    // Yes, its protected.
                                    Protected = true;
                                    break;
                                }
                            }

                            // Do NES CPU jam protection if desired.
                            if (EnableNESCPUJamProtection)
                            {
                                if (!Protected && j >= 2)
                                {
                                    if (NESCPUJamProtection_Avoid.Contains(ROM[i])
                                        || NESCPUJamProtection_Protect_1.Contains(ROM[j])
                                        || NESCPUJamProtection_Protect_2.Contains(ROM[j - 1])
                                        || NESCPUJamProtection_Protect_3.Contains(ROM[j - 2]))
                                    {
                                        Protected = true;
                                    }
                                }
                            }

                            // If the byte is not protected, corrupt it.
                            if (!Protected)
                            {
                                ROM[j] = ROM[i];
                            }
                        }
                    }
                }
                else if (ByteCorruptionOption == ByteCorruptionOptions.ReplaceByteXwithY && ReplaceByteXwithYByteX != ReplaceByteXwithYByteY)
                {
                    for (long i = StartByte + EveryNthByte; i <= EndByte; i = i + EveryNthByte)
                    {
                        if (ROM[i] == ReplaceByteXwithYByteX)
                        {
                            // If the byte is protected.
                            bool Protected = false;

                            // Check if the byte is protected.
                            foreach (long[] ProtectedRegion in ProtectedRegions)
                            {
                                if (i >= ProtectedRegion[0] && i <= ProtectedRegion[1])
                                {
                                    // Yes, its protected.
                                    Protected = true;
                                    break;
                                }
                            }

                            // If the byte is not protected, corrupt it.
                            if (!Protected)
                            {
                                ROM[i] = ReplaceByteXwithYByteY;
                            }
                        }
                    }
                }
            }

            return ROM;
        }
    }
}
