using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Figlet
{
    /// <summary>
    /// See https://github.com/cmatsuoka/figlet.
    /// </summary>
    public class FigletFont
    {
        /// <summary>
        /// Standard by Glenn Chappell & Ian Chai 3/93 -- based on Frank's .sig
        /// </summary>
        public static FigletFont Standard => Parse(DefaultFonts.Standard, "Standard");

        /// <summary>
        /// Slant by Glenn Chappell 3/93 -- based on Standard
        /// </summary>
        public static FigletFont Slant => Parse(DefaultFonts.Slant, "Slant");

        /// <summary>
        /// Script by Glenn Chappell 4/93
        /// </summary>
        public static FigletFont Script => Parse(DefaultFonts.Script, "Script");

        /// <summary>
        /// Big by Glenn Chappell 4/93 -- based on Standard
        /// </summary>
        public static FigletFont Big => Parse(DefaultFonts.Big, "Big");

        /// <summary>
        /// Small by Glenn Chappell 4/93 -- based on Standard
        /// </summary>
        public static FigletFont Small => Parse(DefaultFonts.Small, "Small");

        /// <summary>
        /// SmSlant by Glenn Chappell 6/93 - based on Small & Slant
        /// </summary>
        public static FigletFont SmallSlant => Parse(DefaultFonts.SmallSlant, "SmallSlant");

        /// <summary>
        /// SmScript by Glenn Chappell 4/93 -- based on Script
        /// </summary>
        public static FigletFont SmallScript => Parse(DefaultFonts.SmallScript, "SmallScript");

        /// <summary>
        /// Figlet conversion by Kent Nassen, knassen@umich.edu, 1/2/95
        /// </summary>
        public static FigletFont Crawford => Parse(DefaultFonts.Crawford, "Crawford");

        /// <summary>
        /// DOOM by Frans P. de Vries 18 Jun 1996
        /// </summary>
        public static FigletFont Doom => Parse(DefaultFonts.Doom, "Doom");

        /// <summary>
        /// No description given
        /// </summary>
        public static FigletFont Ogre => Parse(DefaultFonts.Ogre, "Ogre");

        /// <summary>
        /// Authors : Myflix, LG Beard
        /// </summary>
        public static FigletFont FlowerPower => Parse(DefaultFonts.FlowerPower, "FlowerPower");

        /// <summary>
        /// Rounded by Nick Miners N.M.Miners@durham.ac.uk
        /// </summary>
        public static FigletFont Rounded => Parse(DefaultFonts.Rounded, "Rounded");

        /// <summary>
        /// Puffy.flf by Juan Car (jc@juguete.quim.ucm.es)
        /// </summary>
        public static FigletFont Puffy => Parse(DefaultFonts.Puffy, "Puffy");

        /// <summary>
        /// Author : LG Beard
        /// </summary>
        public static FigletFont Merlin1 => Parse(DefaultFonts.Merlin1, "Merlin1");

        /// <summary>
        /// This figlet font designed by Leigh Purdie (purdie@zeus.usq.edu.au)
        /// </summary>
        public static FigletFont Graffiti => Parse(DefaultFonts.Graffiti, "Graffiti");

        /// <summary>
        /// Author : LG Beard
        /// </summary>
        public static FigletFont Twisted => Parse(DefaultFonts.Twisted, "Twisted");

        /// <summary>
        /// Author : myflix
        /// </summary>
        public static FigletFont Soft => Parse(DefaultFonts.Soft, "Soft");

        /// <summary>
        /// Author : LG Beard
        /// </summary>
        public static FigletFont SmallCaps => Parse(DefaultFonts.SmallCaps, "SmallCaps");

        /// <summary>
        /// Author : LG Beard
        /// </summary>
        public static FigletFont Braced => Parse(DefaultFonts.Braced, "Braced");

        /// <summary>
        /// Figletized by Wendell Hicken 11/93 (whicken@parasoft.com)
        /// </summary>
        public static FigletFont Thin => Parse(DefaultFonts.Thin, "Thin");

        /// <summary>
        /// Author : Christian 'CeeJay' Jensen 2005/6/19
        /// </summary>
        public static FigletFont Swan => Parse(DefaultFonts.Swan, "Swan");

        /// <summary>
        /// Author : mikechat, 2006/6/9
        /// </summary>
        public static FigletFont DietCola => Parse(DefaultFonts.DietCola, "DietCola");

        /// <summary>
        /// Conversion to FigLet font by MEPH
        /// </summary>
        public static FigletFont SubZero => Parse(DefaultFonts.SubZero, "SubZero");

        /// <summary>
        /// Larry3D.flf by Larry Gelberg (larryg@avs.com)
        /// </summary>
        public static FigletFont Larry3D => Parse(DefaultFonts.Larry3D, "Larry3D");

        /// <summary>
        /// Shadow by Glenn Chappell 6/93 -- based on Standard & SmShadow
        /// </summary>
        public static FigletFont Shadow => Parse(DefaultFonts.Shadow, "Shadow");

        /// <summary>
        /// SmShadow by Glenn Chappell 4/93 -- based on Small
        /// </summary>
        public static FigletFont SmallShadow => Parse(DefaultFonts.SmallShadow, "SmallShadow");

        /// <summary>
        /// Block by Glenn Chappell 4/93 -- straight version of Lean
        /// </summary>
        public static FigletFont Block => Parse(DefaultFonts.Block, "Block");

        /// <summary>
        /// Lean by Glenn Chappell 4/93
        /// </summary>
        public static FigletFont Lean => Parse(DefaultFonts.Lean, "Lean");

        /// <summary>
        /// banner.flf version 2 by Ryan Youck (youck@cs.uregina.ca)
        /// </summary>
        public static FigletFont Banner => Parse(DefaultFonts.Banner, "Banner");

        /// <summary>
        /// Figlet translation by Kent Nassen, kentn@cyberspace.org, 1/2/95
        /// </summary>
        public static FigletFont Broadway => Parse(DefaultFonts.Broadway, "Broadway");

        /// <summary>
        /// Basic.flf by Craig O'Flaherty, August 17, 1994
        /// </summary>
        public static FigletFont Basic => Parse(DefaultFonts.Basic, "Basic");

        /// <summary>
        /// Named after the login of a woman who  asked me to make her a sig, by vampyr@acs.bu.edu
        /// </summary>
        public static FigletFont NancyJ => Parse(DefaultFonts.NancyJ, "NancyJ");

        /// <summary>
        /// Univers by Normand Veilleux, 5 Mar 1994
        /// </summary>
        public static FigletFont Univers => Parse(DefaultFonts.Univers, "Univers");

        /// <summary>
        /// Fraktur.flf by Philip Menke (philippe@dds.nl), May 1995
        /// </summary>
        public static FigletFont Fraktur => Parse(DefaultFonts.Fraktur, "Fraktur");

        /// <summary>
        /// The name of the font.
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// The signature is the first five characters of the header line: "flf2a".
        /// The first four characters "flf2" identify the file as compatible with FIGlet version 2.0 or later (and FIGWin 1.0).
        /// The "a" is currently ignored, but cannot be omitted.
        /// Different characters in the "a" location may mean something in future versions of this standard.
        /// If so, you can be sure your FIG fonts will still work if this character is "a".
        /// </summary>
        // ReSharper disable once MemberCanBePrivate.Global
        // ReSharper disable once UnusedAutoPropertyAccessor.Global
        public string Signature { get; private set; }

        /// <summary>
        /// The hardblank character in the header line defines which sub-character will be used to represent hardblanks in the FIG character data.
        /// By convention, the usual hardblank is a "$", but it can be any character except a blank(space), a carriage-return, a newline (linefeed) or a null character.
        /// If you want the entire printable ASCII set available to use, make the hardblank a "delete" character(character code 127).
        /// With the exception of delete, it is inadvisable to use non-printable characters as a hardblank.
        /// </summary>
        // ReSharper disable once MemberCanBePrivate.Global
        // ReSharper disable once UnusedAutoPropertyAccessor.Global
        public char HardBlank { get; private set; }

        /// <summary>
        /// The Height property specifies the consistent height of every FIG character, measured in sub-characters.
        /// Note that ALL FIG characters in a given FIG font have the same height, since this includes any empty space above or below.
        /// This is a measurement from the top of the tallest FIG character to the bottom of the lowest hanging FIG character, such as a lowercase g.
        /// </summary>
        public int Height { get; private set; }

        /// <summary>
        /// The BaseLine property is the number of lines of sub-characters from the baseline of a FIG character to the top of the tallest FIG character.
        /// The baseLine of a FIG font is an imaginary line on top of which capital letters would rest, while the tails of lowercase g, j, p, q, and y may hang below.
        /// In other words, BaseLine is the height of a FIG character, ignoring any descenders.
        ///
        /// This property does not affect the output of FIGlet 2.2 or FIGWin 1.0, but future versions or other future FIG drivers may use it.
        /// The BaseLine property should be correctly set to reflect the true baseline as described above.
        /// It is an error for BaseLine to be less than 1 or greater than the <see cref="Height"/> property.
        /// </summary>
        // ReSharper disable once MemberCanBePrivate.Global
        // ReSharper disable once UnusedAutoPropertyAccessor.Global
        public int BaseLine { get; private set; }

        /// <summary>
        /// The MaxLength property is the maximum length of any line describing a FIG character.
        /// This is usually the width of the widest FIG character, plus 2 (to accommodate end marks as described later).
        /// However, you can (and probably should) set MaxLength slightly larger than this as a safety measure in case your FIG font is edited to include wider FIG characters.
        /// FIGlet (but not FIGWin 1.0) uses this number to minimize the memory taken up by a FIG font, which is important in the case of FIG fonts with many FIG characters.
        /// </summary>
        // ReSharper disable once MemberCanBePrivate.Global
        // ReSharper disable once UnusedAutoPropertyAccessor.Global
        public int MaxLength { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        // ReSharper disable once MemberCanBePrivate.Global
        // ReSharper disable once UnusedAutoPropertyAccessor.Global
        public int OldLayout { get; private set; }

        /// <summary>
        /// Between the first line and the actual FIG characters of the FIG font are the comment lines.
        /// The CommentLines property specifies how many lines there are.
        /// Comments are optional, but recommended to properly document the origin of a FIG font.
        /// </summary>
        // ReSharper disable once MemberCanBePrivate.Global
        // ReSharper disable once UnusedAutoPropertyAccessor.Global
        public int CommentLines { get; private set; }

        /// <summary>
        /// The PrintDirection property tells which direction the font is to be printed by default.
        /// A value of 0 means left-to-right, and 1 means right-to-left.
        /// If this parameter is absent, 0 (left-to-right) is assumed.
        /// Versions of FIGlet prior to 2.1 ignore this parameter.
        /// </summary>
        // ReSharper disable once MemberCanBePrivate.Global
        // ReSharper disable once UnusedAutoPropertyAccessor.Global
        public int PrintDirection { get; private set; }

        // ReSharper disable once MemberCanBePrivate.Global
        // ReSharper disable once UnusedAutoPropertyAccessor.Global
        public int FullLayout { get; private set; }

        /// <summary>
        /// Indicates the number of code-tagged (non-required) FIG characters in this FIG font.
        /// This is always equal to the total number of FIG characters in the font minus 102.
        /// This parameter is typically ignored by FIG drivers, but can be used to verify that no characters are missing from the end of the FIG font.
        /// </summary>
        // ReSharper disable once MemberCanBePrivate.Global
        // ReSharper disable once UnusedAutoPropertyAccessor.Global
        public int CodeTagCount { get; private set; }

        /// <summary>
        /// The character lines of the font.
        /// </summary>
        private Dictionary<int, string[]> charDictionary;

        /// <summary>
        /// Between the first line and the actual FIG characters of the FIG font are the comment lines.
        /// The Comment property holds a multi-line text of these comments.
        /// The number of lines is specified by the <see cref="CommentLines"/> property.
        /// Comments are optional, but recommended to properly document the origin of a FIG font.
        /// </summary>
        // ReSharper disable once MemberCanBePrivate.Global
        // ReSharper disable once UnusedAutoPropertyAccessor.Global
        public string Commit { get; private set; }

        // ReSharper disable once UnusedMember.Global
        public static FigletFont Load(byte[] bytes, string fontName)
        {
            using var stream = new MemoryStream(bytes);
            return Load(stream, fontName);
        }

        // ReSharper disable once MemberCanBePrivate.Global
        public static FigletFont Load(Stream stream, string fontName)
        {
            var fontLines = new List<string>();
            using (var streamReader = new StreamReader(stream))
            {
                while (!streamReader.EndOfStream)
                {
                    fontLines.Add(streamReader.ReadLine());
                }
            }

            return Parse(fontLines, fontName);
        }

        // ReSharper disable once UnusedMember.Global
        public static FigletFont Load(string filePath, string fontName)
        {
            return Parse(File.ReadLines(filePath), fontName);
        }

        // ReSharper disable once MemberCanBePrivate.Global
        public static FigletFont Parse(string fontContent, string fontName)
        {
            return Parse(fontContent.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.None), fontName);
        }

        // ReSharper disable once MemberCanBePrivate.Global
        public static FigletFont Parse(IEnumerable<string> fontLines, string fontName)
        {
            var lines = fontLines.ToArray();
            var lineCount = lines.Length;

            string[] configs = lines[0].Split(' ');
            if (!configs[0].StartsWith("flf2a"))
            {
                throw new ArgumentException($"Invalid font signature [{configs[0]}], [flf2a] expected", nameof(fontLines));
            }

            int commentLines = ParseIntValue(configs, 5);
            if (lineCount < 1 + commentLines)
            {
                throw new ArgumentException($"Invalid number of lines in the font [{lineCount}], should be > than [{commentLines} + 1]", nameof(fontLines));
            }

            StringBuilder commentBuilder = new StringBuilder();
            int i = 1;
            for (; i < commentLines + 1; ++i)
            {
                commentBuilder.AppendLine(lines[i] ?? string.Empty);
            }

            int currentChar = 32;
            char hardBlank = configs[0].Last();
            int height = ParseIntValue(configs, 1);
            var fontChars = new Dictionary<int, string[]>();

            while (i < lineCount)
            {
                string currentLine = lines[i++] ?? string.Empty;
                if (int.TryParse(currentLine, out var charIndex))
                {
                    currentChar = charIndex;
                }

                fontChars.Add(currentChar, new string[height]);
                int currentLineIndex = 0;
                while (currentLineIndex < height)
                {
                    fontChars[currentChar][currentLineIndex] = currentLine.TrimEnd('@').Replace(hardBlank, ' ');
                    if (currentLine.EndsWith(@"@@"))
                    {
                        break;
                    }

                    if (i >= lineCount)
                    {
                        // throw new ArgumentException($"Invalid number of lines in the font [{lineCount}], current character [{currentChar}], character line index [{currentLineIndex}] < [{height}]", nameof(fontLines));
                        break;
                    }

                    currentLine = lines[i++] ?? string.Empty;
                    currentLineIndex++;
                }

                currentChar++;
            }

            return new FigletFont
            {
                Signature = "flf2a",
                HardBlank = hardBlank,
                Height = height,
                BaseLine = ParseIntValue(configs, 2),
                MaxLength = ParseIntValue(configs, 3),
                OldLayout = ParseIntValue(configs, 4),
                CommentLines = commentLines,
                PrintDirection = ParseIntValue(configs, 6),
                FullLayout = ParseIntValue(configs, 7),
                CodeTagCount = ParseIntValue(configs, 8),
                Commit = commentBuilder.ToString(),
                charDictionary = fontChars,
                Name = fontName
            };
        }

        public string GetCharacter(char sourceChar, int line)
        {
            if (line < 0 || line >= Height)
            {
                throw new ArgumentOutOfRangeException(nameof(line));
            }

            int sourceInt = sourceChar;
            if (charDictionary.TryGetValue(sourceInt, out string[] sourceArray))
            {
                if (line >= sourceArray.Length)
                {
                    throw new ArgumentOutOfRangeException($"Character '{sourceChar}' ({sourceInt}) contains {sourceArray.Length} lines, line {line} was requested.", nameof(line));
                }

                return sourceArray[line];
            }

            return string.Empty;
        }

        private static int ParseIntValue(string[] values, int index)
        {
            var integer = 0;

            if (values.Length > index)
            {
                int.TryParse(values[index], out integer);
            }

            return integer;
        }
    }
}
