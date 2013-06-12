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
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace Vinesauce_ROM_Corruptor
{
    class RomId
    {
        static SHA256 SHA = SHA256Managed.Create();

        public string FilePath = "";
        public string FileName = "";
        public long FileLength = 0;
        public byte[] Hash = null;
        public string HashStringBase64 = "";

        public RomId(string FilePath)
        {
            this.FilePath = FilePath;
            this.FileName = Path.GetFileName(FilePath);

            try
            {
                FileInfo fi = new FileInfo(FilePath);
                this.FileLength = fi.Length;
            }
            catch
            {
                // Do nothing.
            }
        }

        public ListViewItem GetListViewItem()
        {
            ListViewItem item = new ListViewItem(new string[] { FileName });
            item.Tag = this;
            return item;
        }

        public byte[] Load()
        {
            try
            {
                return File.ReadAllBytes(FilePath);
            }
            catch
            {
                return null;
            }
        }

        public bool MatchesHash(byte[] OtherHash)
        {
            if (OtherHash == null)
            {
                return false;
            }
            return OtherHash.SequenceEqual(Hash);
        }

        public bool MatchesFileName(string OtherFileName)
        {
            if (OtherFileName == "")
            {
                return false;
            }
            return OtherFileName == FileName;
        }

        public bool MatchesFileLength(long OtherFileLength)
        {
            if (OtherFileLength < 1)
            {
                return false;
            }
            return OtherFileLength == FileLength;
        }

        public void ComputeHash()
        {
            if (Hash == null)
            {
                FileInfo fi = new FileInfo(FilePath);
                FileStream fs = fi.OpenRead();
                Hash = SHA.ComputeHash(fs);
                fs.Close();
                HashStringBase64 = Convert.ToBase64String(Hash);
            }
        }

    }
}