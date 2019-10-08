namespace Figlet
{
    /// <summary>
    /// Horizontal layout modes which define the spacing between FIG characters.
    /// See https://github.com/cmatsuoka/figlet.
    /// </summary>
    public enum FigletLayout
    {
        /// <summary>
        /// Moves FIG characters one step closer after they touch, so that they partially occupy the same space.
        /// </summary>
        /// <remarks>

        /// </remarks>
        Smush,

        /// <summary>
        /// Moves FIG characters closer together until they touch.
        /// Typographers use the term "kerning" for this phenomenon when applied to the horizontal axis.
        /// </summary>
        Kerning,

        /// <summary>
        /// Represents each FIG character occupying the full width of its arrangement of sub-characters as designed.
        /// </summary>
        FullWidth
    }

    // -------------------------------------------------------------------------------------------------------------
    // SMUSHING
    //
    // One must decide what sub-character to display at each junction.
    // There are two ways of making these decisions: by controlled smushing or by universal smushing.
    //
    // Universal smushing simply overrides the sub-character from the earlier FIG character with the sub-character from the later FIG character.
    // This produces an "overlapping" effect with some FIG fonts, wherein the latter FIG character may appear to be "in front".
    //
    // Controlled smushing uses a set of "smushing rules" selected by the designer of a FIG font.
    // Each rule is a comparison of the two sub-characters which must be joined to yield what to display at the junction.
    // Controlled smushing will not always allow smushing to occur, because the compared sub-characters may not correspond to any active rule.
    // Wherever smushing cannot occur, fitting occurs instead.
    //
    // There are six possible horizontal smushing rules.
    //
    // Rule 1: EQUAL CHARACTER SMUSHING (code value 1)
    // Two sub-characters are smushed into a single sub-character if they are the same.
    // This rule does not smush hardblanks.  (See "Hardblanks" below.)
    //
    // Rule 2: UNDERSCORE SMUSHING (code value 2)
    // An underscore ("_") will be replaced by any of: "|", "/", "\", "[", "]", "{", "}", "(", ")", "<" or ">".
    //
    // Rule 3: HIERARCHY SMUSHING(code value 4)
    // A hierarchy of six classes is used: "|", "/\", "[]", "{}", "()", and "<>".
    // When two smushing sub-characters are from different classes, the one from the latter class will be used.
    //
    // Rule 4: OPPOSITE PAIR SMUSHING (code value 8)
    // Smushes opposing brackets("[]" or "]["), braces("{}" or "}{") and parentheses("()" or ")(") together, replacing any such pair with a vertical bar("|").
    //
    // Rule 5: BIG X SMUSHING(code value 16)
    // Smushes "/\" into "|", "\/" into "Y", and "><" into "X". Note that "<>" is not smushed in any way by this rule.
    // The name "BIG X" is historical; originally all three pairs were smushed into "X".
    //
    // Rule 6: HARDBLANK SMUSHING (code value 32)
    // Smushes two hardblanks together, replacing them with a single hardblank.  (See "Hardblanks" below.)
    //
    // -------------------------------------------------------------------------------------------------------------
    // HARDBLANKS
    //
    // A hardblank is a special sub-character which is displayed as a blank(space) in rendered FIGures,
    // but is treated more like a "visible" sub-character when fitting or smushing horizontally.
    // Therefore, hardblanks keep adjacent FIG characters a certain distance apart.
    // -------------------------------------------------------------------------------------------------------------
}
