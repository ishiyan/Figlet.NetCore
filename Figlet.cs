using System;
using System.Text;

namespace Figlet
{
    /// <summary>
    /// The FIGlet driver.
    /// See https://github.com/cmatsuoka/figlet.
    /// </summary>
    public static class Figlet
    {
        private static readonly string[] Separators = { "\r\n", "\r", "\n" };

        /// <summary>
        /// Renders an ASCII art from a multi-line text.
        /// The number of lines is equal to the <see cref="linesRendered"/> times the <see cref="FigletFont.Height"/> property of the <see cref="font"/>.
        /// </summary>
        /// <param name="text">The text to render.</param>
        /// <param name="font">The <see cref="FigletFont"/> to render.</param>
        /// <param name="layout">The <see cref="FigletLayout"/> to render.</param>
        /// <param name="linesRendered">How many lines were rendered.</param>
        /// <returns>The multi-line string with rendered ASCII art.</returns>
        public static string RenderAsciiArt(string text, FigletFont font, FigletLayout layout, out int linesRendered)
        {
            var lines = text.Split(Separators, StringSplitOptions.None);
            linesRendered = lines.Length;
            if (linesRendered < 2)
                return RenderAsciiArtLine(text, font, layout);

            var stringBuilder = new StringBuilder();
            foreach (var line in lines)
            {
                stringBuilder.Append(RenderAsciiArtLine(line, font, layout));
            }

            return stringBuilder.ToString();
        }

        /// <summary>
        /// Renders an ASCII art from a single-line text.
        /// The number of rendered lines is equal to the <see cref="FigletFont.Height"/> property of the <see cref="font"/>.
        /// </summary>
        /// <param name="text">The text to render.</param>
        /// <param name="font">The <see cref="FigletFont"/> to render.</param>
        /// <param name="layout">The <see cref="FigletLayout"/> to render.</param>
        /// <returns>The multi-line string with rendered ASCII art.</returns>
        // ReSharper disable once MemberCanBePrivate.Global
        public static string RenderAsciiArtLine(string text, FigletFont font, FigletLayout layout)
        {
            var height = font.Height;
            var stringBuilder = new StringBuilder();

            if (text.Length == 0)
            {
                while (height-- > 0)
                {
                    stringBuilder.AppendLine(String.Empty);
                }

                return stringBuilder.ToString();
            }

            if (Encoding.UTF8.GetByteCount(text) != text.Length)
            {
                throw new ArgumentException($"Text to render [{text}] contains non-ascii characters", nameof(text));
            }

            if (text.Contains(Environment.NewLine))
            {
                throw new ArgumentException("Text to render cannot contain multiple lines.", nameof(text));
            }

            var result = new string[height];
            switch (layout)
            {
                case FigletLayout.FullWidth:
                    for (int currentLine = 0; currentLine < height; ++currentLine)
                    {
                        stringBuilder.Clear();
                        foreach (char currentChar in text)
                        {
                            stringBuilder.Append(font.GetCharacter(currentChar, currentLine));
                            stringBuilder.Append(' ');
                        }

                        result[currentLine] = stringBuilder.ToString();
                    }
                    break;

                case FigletLayout.Kerning:
                    for (int currentLine = 0; currentLine < height; ++currentLine)
                    {
                        stringBuilder.Clear();
                        foreach (char currentChar in text)
                        {
                            stringBuilder.Append(font.GetCharacter(currentChar, currentLine));
                        }

                        result[currentLine] = stringBuilder.ToString();
                    }

                    break;

                case FigletLayout.Smush:
                    for (int currentLine = 0; currentLine < height; currentLine++)
                    {
                        stringBuilder.Clear();
                        stringBuilder.Append(font.GetCharacter(text[0], currentLine));
                        char lastChar = text[0];
                        var length = text.Length;
                        for (int currentCharIndex = 1; currentCharIndex < length; currentCharIndex++)
                        {
                            char currentChar = text[currentCharIndex];
                            string currentCharacterLine = font.GetCharacter(currentChar, currentLine);
                            if (lastChar != ' ' && currentChar != ' ' && currentCharacterLine.Length > 0)
                            {
                                if (stringBuilder[^1] == ' ')
                                {
                                    stringBuilder[^1] = currentCharacterLine[0];
                                }
                                stringBuilder.Append(currentCharacterLine.Substring(1));
                            }
                            else
                            {
                                stringBuilder.Append(currentCharacterLine);
                            }
                            lastChar = currentChar;
                        }

                        result[currentLine] = stringBuilder.ToString();
                    }
                    break;
            }

            stringBuilder.Clear();
            foreach (var s in result)
            {
                stringBuilder.AppendLine(s);
            }

            return stringBuilder.ToString();
        }
    }
}
