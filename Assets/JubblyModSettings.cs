using System;
using System.Collections.Generic;
using System.Linq;

public class JubblyModSettings
{
    public string A = "ASS,AMOGUS,ARMPIT";
    public string B = "BALLS,BOINKY,BASED,BITCHY,BUSSIN,BOOTY,BITCHES,BUSSY";
    public string C = "CRINKLE,CRINGE,CHUNGUS,COCK";
    public string D = "DUMPY,DICK,DOINKY,DIGGITY,DOOF";
    public string E = "EUPHEMISM,EGGY,EDGY,EGIRL,EXISH";
    public string F = "FUGLY,FUNNY,FRICK,FART,FATTY,FORTNITE";
    public string G = "GANGLY,GOBBLE,GRUNKLE,GIGGITY,GOOBER";
    public string H = "HOES,HORNY,HONKERS,HEFTY";
    public string I = "INCY,ITCHY,ICKLE,IRISH";
    public string J = "JUNK,JIGGLE,JOHNSON,JERK,JINKIES";
    public string K = "KINK,KNICKERS,KNOBBLY";
    public string L = "LIGMA,LANKY,LUMPY,LEAN,LIMP";
    public string M = "MANCY,MILKERS,MEATY,MORBIUS";
    public string N = "NANCY,NIBBLE,NUTS";
    public string O = "OOF,OBESE,OWO,OUCHIE";
    public string P = "PLOPPERS,POGGERS,PUSS,PLUMP,PUSSY,PENILE";
    public string R = "RUMPY,RACISM,ROWDY,RUBBER";
    public string S = "SUGMA,SLOPPY,SUSSY,SQUEEZY,SNIFF,SHREK,SPONGEBOB,SEINFELD,SCRUNKLY";
    public string T = "TIDDLY,THICC,TICKLE,TESTY,TWITCHY";
    public string U = "UGLY,UWU,UGANDAN,UNDERTALE";
    public string V = "VIBIN,VEINY,VORE,VOLUPTUOUS";
    public string W = "WIBBLE,WHIZZIE,WHOOPIE,WONKY,WINCY,WACKY,WEEZER";
    public string Y = "YIPPEE,YOINK,YOWZERS,YIKES,YEOWZA";
    public string Z = "ZOINKS,ZAMN,ZIPPY";

    public Dictionary<char, List<string>> GetDict()
    {
        return new Dictionary<char, List<string>>()
        {
            { 'A', FormatString(A) },
            { 'B', FormatString(B) },
            { 'C', FormatString(C) },
            { 'D', FormatString(D) },
            { 'E', FormatString(E) },
            { 'F', FormatString(F) },
            { 'G', FormatString(G) },
            { 'H', FormatString(H) },
            { 'I', FormatString(I) },
            { 'J', FormatString(J) },
            { 'K', FormatString(K) },
            { 'L', FormatString(L) },
            { 'M', FormatString(M) },
            { 'N', FormatString(N) },
            { 'O', FormatString(O) },
            { 'P', FormatString(P) },
            { 'R', FormatString(R) },
            { 'S', FormatString(S) },
            { 'T', FormatString(T) },
            { 'U', FormatString(U) },
            { 'V', FormatString(V) },
            { 'W', FormatString(W) },
            { 'Y', FormatString(Y) },
            { 'Z', FormatString(Z) },
        };
    }
    private static List<string> FormatString(string input)
    {
        return input.ToUpperInvariant().Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries).Select(str => str.Trim()).ToList();
    }
}