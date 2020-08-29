using AltV.Net;
using System.Collections.Generic;

namespace VenoXV.Wiki
{
    public class GtaSaVehicleModel
    {
        public string SA_VehicleModel { get; set; }
        public int SA_VehicleID { get; set; }
        public string V_VehicleModel { get; set; }
        public uint V_VehicleModelHash { get; set; }
        public string Info { get; set; }
        public GtaSaVehicleModel(string SA_VehicleModel, int SA_VehicleID, string V_VehicleModel, uint V_VehicleModelHash, string Info = "")
        {
            this.SA_VehicleModel = SA_VehicleModel;
            this.SA_VehicleID = SA_VehicleID;
            this.V_VehicleModel = V_VehicleModel;
            this.V_VehicleModelHash = V_VehicleModelHash;
            this.Info = Info;
        }
    }
    /* We create our IScript class */
    public class AltV_Wiki : IScript
    {
        private const string MODEL_DONT_EXIST = "Für dieses Fahrzeug exestiert kein ähnliches Model!";
        public static List<GtaSaVehicleModel> GtaSA_VehicleMap = new List<GtaSaVehicleModel>()
        {
            new GtaSaVehicleModel("Landstalker",    400,    "landstalker",  1269098716),
            new GtaSaVehicleModel("Bravura",        401,    "primo",        3144368207),
            new GtaSaVehicleModel("Buffalo",        402,    "dominator",    80636076),
            new GtaSaVehicleModel("Linerunner",     403,    "phantom",      2157618379),
            new GtaSaVehicleModel("Perennial",      404,    "regina",       4280472072),
            new GtaSaVehicleModel("Sentinel",       405,    "intruder",     886934177),
            new GtaSaVehicleModel("Dumper",         406,    "dump",         2164484578),
            new GtaSaVehicleModel("Firetruck",      407,    "firetruk",     1938952078),
            new GtaSaVehicleModel("Trashmaster",    408,    "trash",        1917016601),
            new GtaSaVehicleModel("Stretch",        409,    "stretch",      2333339779),
            new GtaSaVehicleModel("Manana",         410,    "intruder",     886934177),
            new GtaSaVehicleModel("Infernus",       411,    "krieger",      3630826055),
            new GtaSaVehicleModel("Voodoo",         412,    "voodoo",       2006667053),
            new GtaSaVehicleModel("Pony",           413,    "pony",         4175309224),
            new GtaSaVehicleModel("Mule",           414,    "mule",         904750859),
            new GtaSaVehicleModel("Cheetah",        415,    "bullet",       2598821281),
            new GtaSaVehicleModel("Ambulance",      416,    "ambulance",    1171614426),
            new GtaSaVehicleModel("Leviathan",      417,    "cargobob",     4244420235),
            new GtaSaVehicleModel("Moonbeam",       418,    "moonbeam",     525509695),
            new GtaSaVehicleModel("Esperanto",      419,    "virgo2",       3395457658),
            new GtaSaVehicleModel("Taxi",           420,    "taxi",         3338918751),
            new GtaSaVehicleModel("Washington",     421,    "washington",   1777363799),
            new GtaSaVehicleModel("Bobcat",         422,    "rebel",        3087195462),
            new GtaSaVehicleModel("Mr. Whoopee",    423,    "taco",         1951180813),
            new GtaSaVehicleModel("BF Injection",   424,    "bifta",        3945366167),
            new GtaSaVehicleModel("Hunter",         425,    "hunter",       4252008158),
            new GtaSaVehicleModel("Premier",        426,    "primo",        2411098011),
            new GtaSaVehicleModel("Enforcer",       427,    "policet",      456714581),
            new GtaSaVehicleModel("Securicar",      428,    "stockade",     1747439474),
            new GtaSaVehicleModel("Banshee",        429,    "banshee",      3253274834),
            new GtaSaVehicleModel("Predator",       430,    "predator",     3806844075),
            new GtaSaVehicleModel("Bus",            431,    "bus",          3581397346),
            new GtaSaVehicleModel("Rhino",          432,    "rhino",        782665360),
            new GtaSaVehicleModel("Barracks",       433,    "barracks",     3471458123),
            new GtaSaVehicleModel("Hotknife",       434,    "hotknife",     37348240),
            new GtaSaVehicleModel("Article Trailer",435,    "tvtrailer",    2524324030),
            new GtaSaVehicleModel("Previon",        436,    "primo",        2411098011),
            new GtaSaVehicleModel("Coach",          437,    "coach",        2222034228),
            new GtaSaVehicleModel("Cabbie",         438,    "taxi",         3338918751),
            new GtaSaVehicleModel("Stallion",       439,    "sentinel",     1349725314),
            new GtaSaVehicleModel("Rumpo",          440,    "rumpo",        1162065741),
            new GtaSaVehicleModel("RC Bandit",      441,    "rcbandito",    4008920556),
            new GtaSaVehicleModel("Romero",         442,    "romero",       627094268),
            new GtaSaVehicleModel("Packer",         443,    "Packer",       569305213),
            new GtaSaVehicleModel("Monster",        444,    "sandking",     3105951696),
            new GtaSaVehicleModel("Admiral",        445,    "intruder",     886934177),
            new GtaSaVehicleModel("Squallo",        446,    "squalo",       400514754),
            new GtaSaVehicleModel("Seasparrow",     447,    "seasparrow",   3568198617),
            new GtaSaVehicleModel("Pizzaboy",       448,    "faggio",       2452219115),
            new GtaSaVehicleModel("Tram",           449,    "metrotrain",   868868440),
            new GtaSaVehicleModel("ArticleTrailer2",450,    "trailers4",    3194418602),
            new GtaSaVehicleModel("Turismo",        451,    "turismo2",     3312836369),
            new GtaSaVehicleModel("Speeder",        452,    "speeder",      231083307),
            new GtaSaVehicleModel("Reefer",         453,    "marquis",      3251507587),
            new GtaSaVehicleModel("Tropic",         454,    "marquis",      3251507587),
            new GtaSaVehicleModel("Flatbed",        455,    "Flatbed",      1353720154),
            new GtaSaVehicleModel("Yankee",         456,    "mule",         904750859),
            new GtaSaVehicleModel("Caddy",          457,    "caddy",        1147287684),
            new GtaSaVehicleModel("Solair",         458,    "stratum",      1723137093),
            new GtaSaVehicleModel("Topfun Van",     459,    "pony",         4175309224),
            new GtaSaVehicleModel("Skimmer",        460,    "duster",       970356638),
            new GtaSaVehicleModel("PCJ-600",        461,    "pcj",          3385765638),
            new GtaSaVehicleModel("Faggio",         462,    "faggio",       2452219115),
            new GtaSaVehicleModel("Freeway",        463,    "hexer",        301427732),
            new GtaSaVehicleModel("RC Baron",       464,    "alphaz1",      2771347558, MODEL_DONT_EXIST),
            new GtaSaVehicleModel("RC Raider",      465,    "alphaz1",      2771347558, MODEL_DONT_EXIST),
            new GtaSaVehicleModel("Glendale",       466,    "glendale",     75131841),
            new GtaSaVehicleModel("Oceanic",        467,    "washington",   1777363799),
            new GtaSaVehicleModel("Sanchez",        468,    "sanchez",      788045382),
            new GtaSaVehicleModel("Sparrow",        469,    "seasparrow",   3568198617),
            new GtaSaVehicleModel("Patriot",        470,    "crusader",     321739290),
            new GtaSaVehicleModel("Quad",           471,    "blazer",       2166734073),
            new GtaSaVehicleModel("Coastguard",     472,    "toro2",        908897389),
            new GtaSaVehicleModel("Dinghy",         473,    "dinghy",       1033245328),
            new GtaSaVehicleModel("Hermes",         474,    "hermes",       15219735),
            new GtaSaVehicleModel("Sabre",          475,    "sabregt",      2609945748),
            new GtaSaVehicleModel("Rustler",        476,    "duster",       970356638),
            new GtaSaVehicleModel("ZR-350",         477,    "furoregt",     3205927392),
            new GtaSaVehicleModel("Walton",         478,    "dloader",      1770332643),
            new GtaSaVehicleModel("Regina",         479,    "regina",       4280472072),
            new GtaSaVehicleModel("Comet",          480,    "comet2",       3249425686),
            new GtaSaVehicleModel("BMX",            481,    "bmx",          1131912276),
            new GtaSaVehicleModel("Burrito",        482,    "burrito2",     3387490166),
            new GtaSaVehicleModel("Camper",         483,    "surfer",       699456151),
            new GtaSaVehicleModel("Marquis",        484,    "marquis",      3251507587),
            new GtaSaVehicleModel("Baggage",        485,    "marquis",      3251507587, MODEL_DONT_EXIST),
            new GtaSaVehicleModel("Dozer",          486,    "bulldozer",    1886712733),
            new GtaSaVehicleModel("Maverick",       487,    "maverick",     2634305738),
            new GtaSaVehicleModel("SANNewsMaverick",488,    "maverick",     2634305738),
            new GtaSaVehicleModel("Rancher",        489,    "rancherxl",    1645267888),
            new GtaSaVehicleModel("Rancher",        490,    "fbi2",         2647026068),
            new GtaSaVehicleModel("Virgo",          491,    "virgo2",       3395457658),
            new GtaSaVehicleModel("Greenwood",      492,    "virgo2",       3395457658),
            new GtaSaVehicleModel("Jetmax",         493,    "jetmax",       861409633),
            new GtaSaVehicleModel("Hotring Racer",  494,    "dominator2",   3379262425),
            new GtaSaVehicleModel("Sandking",       495,    "landstalker2", 3456868130),
            new GtaSaVehicleModel("Sandking",       495,    "landstalker2", 3456868130),



        };
    }
}
