using System;

namespace Figlet
{
    internal static class Program
    {
        static void Main()
        {
            Console.WriteLine("Press vertical arrows to change font spacing, horizontal arrows to change font, Esc to exit.");
            Console.WriteLine();

            var text = "Hello, World!";

            /*
            Console.WriteLine(Figlet.RenderAsciiArtLine(text, FigletFont.Standard, FigletLayout.Smush));
            Console.WriteLine(Figlet.RenderAsciiArtLine(text, FigletFont.Slant, FigletLayout.Smush));
            Console.WriteLine(Figlet.RenderAsciiArtLine(text, FigletFont.Script, FigletLayout.Smush));
            Console.WriteLine(Figlet.RenderAsciiArtLine(text, FigletFont.Big, FigletLayout.Smush));
            Console.WriteLine(Figlet.RenderAsciiArtLine(text, FigletFont.Small, FigletLayout.Smush));
            Console.WriteLine(Figlet.RenderAsciiArtLine(text, FigletFont.SmallSlant, FigletLayout.Smush));
            Console.WriteLine(Figlet.RenderAsciiArtLine(text, FigletFont.SmallScript, FigletLayout.Smush));
            Console.WriteLine(Figlet.RenderAsciiArtLine(text, FigletFont.Crawford, FigletLayout.Smush));
            Console.WriteLine(Figlet.RenderAsciiArtLine(text, FigletFont.Doom, FigletLayout.Smush));
            Console.WriteLine(Figlet.RenderAsciiArtLine(text, FigletFont.Ogre, FigletLayout.Smush));
            Console.WriteLine(Figlet.RenderAsciiArtLine(text, FigletFont.FlowerPower, FigletLayout.Smush));
            Console.WriteLine(Figlet.RenderAsciiArtLine(text, FigletFont.Rounded, FigletLayout.Smush));
            Console.WriteLine(Figlet.RenderAsciiArtLine(text, FigletFont.Puffy, FigletLayout.Smush));
            Console.WriteLine(Figlet.RenderAsciiArtLine(text, FigletFont.Merlin1, FigletLayout.Smush));
            Console.WriteLine(Figlet.RenderAsciiArtLine(text, FigletFont.Graffiti, FigletLayout.Smush));
            Console.WriteLine(Figlet.RenderAsciiArtLine(text, FigletFont.Twisted, FigletLayout.Smush));
            Console.WriteLine(Figlet.RenderAsciiArtLine(text, FigletFont.Soft, FigletLayout.Smush));
            Console.WriteLine(Figlet.RenderAsciiArtLine(text, FigletFont.SmallCaps, FigletLayout.Smush));
            Console.WriteLine(Figlet.RenderAsciiArtLine(text, FigletFont.Braced, FigletLayout.Smush));
            Console.WriteLine(Figlet.RenderAsciiArtLine(text, FigletFont.Thin, FigletLayout.Smush));
            Console.WriteLine(Figlet.RenderAsciiArtLine(text, FigletFont.Swan, FigletLayout.Smush));
            Console.WriteLine(Figlet.RenderAsciiArtLine(text, FigletFont.DietCola, FigletLayout.Smush));
            Console.WriteLine(Figlet.RenderAsciiArtLine(text, FigletFont.SubZero, FigletLayout.Smush));
            Console.WriteLine(Figlet.RenderAsciiArtLine(text, FigletFont.Larry3D, FigletLayout.Smush));
            Console.WriteLine(Figlet.RenderAsciiArtLine(text, FigletFont.Shadow, FigletLayout.Smush));
            Console.WriteLine(Figlet.RenderAsciiArtLine(text, FigletFont.SmallShadow, FigletLayout.Smush));
            Console.WriteLine(Figlet.RenderAsciiArtLine(text, FigletFont.Block, FigletLayout.Smush));
            Console.WriteLine(Figlet.RenderAsciiArtLine(text, FigletFont.Lean, FigletLayout.Smush));
            Console.WriteLine(Figlet.RenderAsciiArtLine(text, FigletFont.Banner, FigletLayout.Smush));
            Console.WriteLine(Figlet.RenderAsciiArtLine(text, FigletFont.Broadway, FigletLayout.Smush));
            Console.WriteLine(Figlet.RenderAsciiArtLine(text, FigletFont.Basic, FigletLayout.Smush));
            Console.WriteLine(Figlet.RenderAsciiArtLine(text, FigletFont.NancyJ, FigletLayout.Smush));
            Console.WriteLine(Figlet.RenderAsciiArtLine(text, FigletFont.Univers, FigletLayout.Smush));
            Console.WriteLine(Figlet.RenderAsciiArtLine(text, FigletFont.Fraktur, FigletLayout.Smush));
            */

            var font = FigletFont.Standard;
            var layout = FigletLayout.Smush;
            Console.Write(Figlet.RenderAsciiArt(text, font, layout, out _));

            while (true)
            {
                var fontPrev = font;
                var key = Console.ReadKey(true);
                if (key.Key == ConsoleKey.Escape)
                    break;
                if (key.Key == ConsoleKey.Backspace)
                {
                    text = text.Remove(text.Length - 1);
                    if (text.Length < 1)
                        text = " ";
                }
                else if (key.Key == ConsoleKey.Enter)
                {
                    text += Environment.NewLine + " ";
                }
                else if (key.Key == ConsoleKey.LeftArrow)
                {
                    layout = PrevLayout(layout);
                }
                else if (key.Key == ConsoleKey.RightArrow)
                {
                    layout = NextLayout(layout);
                }
                else if (key.Key == ConsoleKey.DownArrow)
                {
                    fontPrev = font;
                    font = NextFont(font);
                }
                else if (key.Key == ConsoleKey.UpArrow)
                {
                    fontPrev = font;
                    font = PrevFont(font);
                }
                else
                {
                    text += key.KeyChar;
                }

                var asciiArt = Figlet.RenderAsciiArt(text, font, layout, out int linesRendered);
                ClearLastConsoleLines(fontPrev.Height * linesRendered);
                Console.Write(asciiArt);
                System.Diagnostics.Debug.WriteLine("current font: " + font.Name);
            }
        }

        private static FigletLayout NextLayout(FigletLayout layout)
        {
            return layout switch
            {
                FigletLayout.Smush => FigletLayout.Kerning,
                FigletLayout.Kerning => FigletLayout.FullWidth,
                FigletLayout.FullWidth => FigletLayout.Smush,
                _ => layout
            };
        }

        private static FigletLayout PrevLayout(FigletLayout layout)
        {
            return layout switch
            {
                FigletLayout.Smush => FigletLayout.FullWidth,
                FigletLayout.FullWidth => FigletLayout.Kerning,
                FigletLayout.Kerning => FigletLayout.Smush,
                _ => layout
            };
        }

        private static FigletFont NextFont(FigletFont font)
        {
            return font.Name switch
            {
                "Standard" => FigletFont.Slant,
                "Slant" => FigletFont.Script,
                "Script" => FigletFont.Big,
                "Big" => FigletFont.Small,
                "Small" => FigletFont.SmallSlant,
                "SmallSlant" => FigletFont.SmallScript,
                "SmallScript" => FigletFont.Crawford,
                "Crawford" => FigletFont.Doom,
                "Doom" => FigletFont.Ogre,
                "Ogre" => FigletFont.FlowerPower,
                "FlowerPower" => FigletFont.Rounded,
                "Rounded" => FigletFont.Puffy,
                "Puffy" => FigletFont.Merlin1,
                "Merlin1" => FigletFont.Graffiti,
                "Graffiti" => FigletFont.Twisted,
                "Twisted" => FigletFont.Soft,
                "Soft" => FigletFont.SmallCaps,
                "SmallCaps" => FigletFont.Braced,
                "Braced" => FigletFont.Thin,
                "Thin" => FigletFont.Swan,
                "Swan" => FigletFont.DietCola,
                "DietCola" => FigletFont.SubZero,
                "SubZero" => FigletFont.Larry3D,
                "Larry3D" => FigletFont.Shadow,
                "Shadow" => FigletFont.SmallShadow,
                "SmallShadow" => FigletFont.Block,
                "Block" => FigletFont.Lean,
                "Lean" => FigletFont.Banner,
                "Banner" => FigletFont.Broadway,
                "Broadway" => FigletFont.Basic,
                "Basic" => FigletFont.NancyJ,
                "NancyJ" => FigletFont.Univers,
                "Univers" => FigletFont.Fraktur,
                "Fraktur" => FigletFont.Standard,
                _ => font
            };
        }

        private static FigletFont PrevFont(FigletFont font)
        {
            return font.Name switch
            {
                "Fraktur" => FigletFont.Univers,
                "Univers" => FigletFont.NancyJ,
                "NancyJ" => FigletFont.Basic,
                "Basic" => FigletFont.Broadway,
                "Broadway" => FigletFont.Banner,
                "Banner" => FigletFont.Lean,
                "Lean" => FigletFont.Block,
                "Block" => FigletFont.SmallShadow,
                "SmallShadow" => FigletFont.Shadow,
                "Shadow" => FigletFont.Larry3D,
                "Larry3D" => FigletFont.SubZero,
                "SubZero" => FigletFont.DietCola,
                "DietCola" => FigletFont.Swan,
                "Swan" => FigletFont.Thin,
                "Thin" => FigletFont.Braced,
                "Braced" => FigletFont.SmallCaps,
                "SmallCaps" => FigletFont.Soft,
                "Soft" => FigletFont.Twisted,
                "Twisted" => FigletFont.Graffiti,
                "Graffiti" => FigletFont.Merlin1,
                "Merlin1" => FigletFont.Puffy,
                "Puffy" => FigletFont.Rounded,
                "Rounded" => FigletFont.FlowerPower,
                "FlowerPower" => FigletFont.Ogre,
                "Ogre" => FigletFont.Doom,
                "Doom" => FigletFont.Crawford,
                "Crawford" => FigletFont.SmallScript,
                "SmallScript" => FigletFont.SmallSlant,
                "SmallSlant" => FigletFont.Small,
                "Small" => FigletFont.Big,
                "Big" => FigletFont.Script,
                "Script" => FigletFont.Slant,
                "Slant" => FigletFont.Standard,
                "Standard" => FigletFont.Fraktur,
                _ => font
            };
        }

        private static void ClearLastConsoleLines(int count)
        {
            int top = Console.CursorTop - count;
            if (top < 0)
                top = 0;
            //Console.SetCursorPosition(0, top);
            var blankLine = new string(' ', Console.BufferWidth);
            for (int i = 0; i < count; ++i)
            {
                Console.SetCursorPosition(0, top + i);
                Console.Write(blankLine);
            }

            Console.SetCursorPosition(0, top);
        }
    }
}
