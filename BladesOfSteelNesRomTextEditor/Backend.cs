/**
 * @file           Backend.cs
 * @brief          Class to handle common methods used to read/write the ROM.
 *
 * @copyright      Shawn M. Crawford
 * @date           10/18/2019
 *
 * @remark Author  Shawn M. Crawford
 *
 * @note           N/A
 * 
 */
using System.IO;

namespace BladesOfSteelNesRomTextEditor
{

    /** @brief Backend class to handle common methods used to read/write the ROM. */
    class Backend
    {
        int textFlag = 0;
        private string fullFilename;

        public Backend(string fullFilename)
        {
            this.fullFilename = fullFilename;
        }

        public string GetText(int length, int offset, int table = 0)
        {

            string romCodeString;
            string asciiOut = "";
            string tempHexString;
            int x = 0;
            FileStream fileStream = new FileStream(fullFilename, FileMode.Open, FileAccess.Read);
            fileStream.Seek(offset, SeekOrigin.Begin);

            while (x < length)
            {
                romCodeString = fileStream.ReadByte().ToString("X");
                //if length is single digit add a 0 ( 1 now is 01)
                if (romCodeString.Length == 1)
                {
                    romCodeString = "0" + romCodeString;
                }
                tempHexString = romCodeString;

                if (table == 0)
                {
                    DecodeRomTextGame(tempHexString);
                }
                else
                {
                    DecodeRomTextTitle(tempHexString);
                }

                if (textFlag == 0)
                {
                    if (table == 0)
                    {
                        asciiOut += DecodeRomTextGame(tempHexString);
                    }
                    else
                    {
                        asciiOut += DecodeRomTextTitle(tempHexString);
                    }
                }
                x++;
            }
            fileStream.Close();
            return asciiOut;
        }

        public void UpdateText(int length, string newString, int offset, int table = 0)
        {
            newString = newString.PadRight(length);
            string hexReturn = "";
            string[] newStringArray = new string[length];
            byte[] newStringByteArray = new byte[length];
            int[] newDecimal = new int[length];
            string[] finalString = new string[length];
            string[] newStringHexArray = new string[length];

            int x = 0;
            while (x < length)
            {
                newStringArray[x] = newString[x].ToString();
                string tempAscii = newStringArray[x];
                if (table == 0)
                {
                    hexReturn += EncodeRomTextGame(tempAscii);
                }
                else
                {
                    hexReturn += EncodeRomTextTitle(tempAscii);
                }
                x++;
            }

            int i = 0;
            int j = 0;
            while (i < length)
            {
                newStringHexArray[i] = hexReturn[j] + hexReturn[j + 1].ToString();
                i++;
                j += 2;
            }

            int q = 0;
            while (q < length)
            {
                newDecimal[q] = int.Parse(newStringHexArray[q], System.Globalization.NumberStyles.HexNumber);
                finalString[q] = newDecimal[q].ToString();
                newStringByteArray[q] = byte.Parse(finalString[q]);
                q++;
            }

            using (FileStream fileStream = new FileStream(fullFilename, FileMode.Open, FileAccess.Write))
            {
                fileStream.Seek(offset, SeekOrigin.Begin);
                q = 0;
                while (q < length)
                {
                    fileStream.WriteByte(newStringByteArray[q]);
                    q++;
                }
            }
        }

        private string DecodeRomTextTitle (string tempHexString)
        {
            string romAscii = "";
            textFlag = 0;

            switch (tempHexString)
            {
                case "01":
                    romAscii += "1";
                    break;
                case "02":
                    romAscii += "2";
                    break;
                case "03":
                    romAscii += "8";
                    break;
                case "04":
                    romAscii += "9";
                    break;
                case "05":
                    romAscii += "A";
                    break;
                case "06":
                    romAscii += "B";
                    break;
                case "07":
                    romAscii += "C";
                    break;
                case "08":
                    romAscii += "D";
                    break;
                case "09":
                    romAscii += "E";
                    break;
                case "0A":
                    romAscii += "F";
                    break;
                case "0B":
                    romAscii += "I";
                    break;
                case "0C":
                    romAscii += "K";
                    break;
                case "0D":
                    romAscii += "L";
                    break;
                case "0E":
                    romAscii += "M";
                    break;
                case "0F":
                    romAscii += "N";
                    break;
                case "10":
                    romAscii += "O";
                    break;
                case "11":
                    romAscii += "P";
                    break;
                case "12":
                    romAscii += "R";
                    break;
                case "13":
                    romAscii += "S";
                    break;
                case "14":
                    romAscii += "T";
                    break;
                case "15":
                    romAscii += "U";
                    break;
                case "16":
                    romAscii += "Y";
                    break;
                case "17":
                    romAscii += ".";
                    break;
                case "18":
                    romAscii += ",";
                    break;
                case "19":
                    romAscii += "©";
                    break;
                case "3A":
                    romAscii += " ";
                    break;
                default:
                    romAscii += " ";
                    //textFlag = 1;
                    break;
            }

            return romAscii;
        }

        private string DecodeRomTextGame(string tempHexString)
        {
            string romAscii = "";
            textFlag = 0;

            switch (tempHexString)
            {
                case "DB":
                    romAscii += " ";
                    break;
                case "DC":
                    romAscii += "0";
                    break;
                case "DD":
                    romAscii += "1";
                    break;
                case "DE":
                    romAscii += "2";
                    break;
                case "DF":
                    romAscii += "3";
                    break;
                case "E0":
                    romAscii += "4";
                    break;
                case "E1":
                    romAscii += "5";
                    break;
                case "E2":
                    romAscii += "6";
                    break;
                case "E3":
                    romAscii += "7";
                    break;
                case "E4":
                    romAscii += "8";
                    break;
                case "E5":
                    romAscii += "9";
                    break;
                case "E6":
                    romAscii += "A";
                    break;
                case "E7":
                    romAscii += "B";
                    break;
                case "E8":
                    romAscii += "C";
                    break;
                case "E9":
                    romAscii += "D";
                    break;
                case "EA":
                    romAscii += "E";
                    break;
                case "EB":
                    romAscii += "F";
                    break;
                case "EC":
                    romAscii += "G";
                    break;
                case "ED":
                    romAscii += "H";
                    break;
                case "EE":
                    romAscii += "I";
                    break;
                case "EF":
                    romAscii += "J";
                    break;
                case "F0":
                    romAscii += "K";
                    break;
                case "F1":
                    romAscii += "L";
                    break;
                case "F2":
                    romAscii += "M";
                    break;
                case "F3":
                    romAscii += "N";
                    break;
                case "F4":
                    romAscii += "O";
                    break;
                case "F5":
                    romAscii += "P";
                    break;
                case "F6":
                    romAscii += "Q";
                    break;
                case "F7":
                    romAscii += "R";
                    break;
                case "F8":
                    romAscii += "S";
                    break;
                case "F9":
                    romAscii += "T";
                    break;
                case "FA":
                    romAscii += "U";
                    break;
                case "FB":
                    romAscii += "V";
                    break;
                case "FC":
                    romAscii += "W";
                    break;
                case "FD":
                    romAscii += "X";
                    break;
                case "FE":
                    romAscii += "Y";
                    break;
                case "FF":
                    romAscii += "Z";
                    break;
                default:
                    romAscii += " ";
                    //textFlag = 1;
                    break;
            }

            return romAscii;
        }

        public string EncodeRomTextTitle(string tempAscii)
        {
            string romHex = "";
            tempAscii = tempAscii.ToUpper();

            switch (tempAscii)
            {
                case "1":
                    romHex += "01";
                    break;
                case "2":
                    romHex += "02";
                    break;
                case "8":
                    romHex += "03";
                    break;
                case "9":
                    romHex += "04";
                    break;
                case "A":
                    romHex += "05";
                    break;
                case "B":
                    romHex += "06";
                    break;
                case "C":
                    romHex += "07";
                    break;
                case "D":
                    romHex += "08";
                    break;
                case "E":
                    romHex += "09";
                    break;
                case "F":
                    romHex += "0A";
                    break;
                case "I":
                    romHex += "0B";
                    break;
                case "K":
                    romHex += "0C";
                    break;
                case "L":
                    romHex += "0D";
                    break;
                case "M":
                    romHex += "0E";
                    break;
                case "N":
                    romHex += "0F";
                    break;
                case "O":
                    romHex += "10";
                    break;
                case "P":
                    romHex += "11";
                    break;
                case "R":
                    romHex += "12";
                    break;
                case "S":
                    romHex += "13";
                    break;
                case "T":
                    romHex += "14";
                    break;
                case "U":
                    romHex += "15";
                    break;
                case "Y":
                    romHex += "16";
                    break;
                case ".":
                    romHex += "17";
                    break;
                case ",":
                    romHex += "18";
                    break;
                case "©":
                    romHex += "19";
                    break;
                case " ":
                    romHex += "3A";
                    break;
                default:
                    // space
                    romHex += "3A";
                    break;
            }

            return romHex;
        }

        public string EncodeRomTextGame(string tempAscii)
        {
            string romHex = "";
            tempAscii = tempAscii.ToUpper();

            switch (tempAscii)
            {
                case " ":
                    romHex += "DB";
                    break;
                case "0":
                    romHex += "DC";
                    break;
                case "1":
                    romHex += "DD";
                    break;
                case "2":
                    romHex += "DE";
                    break;
                case "3":
                    romHex += "DF";
                    break;
                case "4":
                    romHex += "E0";
                    break;
                case "5":
                    romHex += "E1";
                    break;
                case "6":
                    romHex += "E2";
                    break;
                case "7":
                    romHex += "E3";
                    break;
                case "8":
                    romHex += "E4";
                    break;
                case "9":
                    romHex += "E5";
                    break;
                case "A":
                    romHex += "E6";
                    break;
                case "B":
                    romHex += "E7";
                    break;
                case "C":
                    romHex += "E8";
                    break;
                case "D":
                    romHex += "E9";
                    break;
                case "E":
                    romHex += "EA";
                    break;
                case "F":
                    romHex += "EB";
                    break;
                case "G":
                    romHex += "EC";
                    break;
                case "H":
                    romHex += "ED";
                    break;
                case "I":
                    romHex += "EE";
                    break;
                case "J":
                    romHex += "EF";
                    break;
                case "K":
                    romHex += "F0";
                    break;
                case "L":
                    romHex += "F1";
                    break;
                case "M":
                    romHex += "F2";
                    break;
                case "N":
                    romHex += "F3";
                    break;
                case "O":
                    romHex += "F4";
                    break;
                case "P":
                    romHex += "F5";
                    break;
                case "Q":
                    romHex += "F6";
                    break;
                case "R":
                    romHex += "F7";
                    break;
                case "S":
                    romHex += "F8";
                    break;
                case "T":
                    romHex += "F9";
                    break;
                case "U":
                    romHex += "FA";
                    break;
                case "V":
                    romHex += "FB";
                    break;
                case "W":
                    romHex += "FC";
                    break;
                case "X":
                    romHex += "FD";
                    break;
                case "Y":
                    romHex += "FE";
                    break;
                case "Z":
                    romHex += "FF";
                    break;
                default:
                    // space
                    romHex += "DB";
                    break;
            }

            return romHex;
        }
    }
}