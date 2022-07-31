using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class JubblyScript : MonoBehaviour {

    public KMAudio Audio;
    public KMBombModule module;
    public List<KMSelectable> buttons;
    public GameObject[] board;
    public Transform buttondown;
    public TextMesh[] displays;
    public Text[] qa;

    private readonly string[][] subblies = new string[24][]
    {
        new string[] { "ASS", "AMOGUS", "ARMPIT"},
        new string[] { "BALLS", "BOINKY", "BASED", "BITCHY", "BUSSIN", "BOOTY"},
        new string[] { "CRINKLE", "CRINGE", "CHUNGUS", "COCK"},
        new string[] { "DUMPY", "DICK", "DOINKY", "DIGGITY"},
        new string[] { "EUPHEMISM", "EGGY", "EDGY", "EGIRL"},
        new string[] { "FUGLY", "FUNNY", "FRICK", "FART", "FATTY"},
        new string[] { "GANGLY", "GOBBLE", "GRUNKLE", "GIGGITY"},
        new string[] { "HOES", "HORNY", "HONKERS", "HEFTY"},
        new string[] { "INCY", "ITCHY", "ICKLE", "IRISH"},
        new string[] { "JUNK", "JIGGLE", "JOHNSON", "JERK"},
        new string[] { "KINK", "KNICKERS", "KNOBBLY"},
        new string[] { "LIGMA", "LANKY", "LUMPY", "LEAN", "LIMP"},
        new string[] { "MANCY", "MILKERS", "MEATY", "MORBIUS"},
        new string[] { "NANCY", "NIBBLE", "NUTS"},
        new string[] { "OOF", "OBESE", "OWO", "OUCHIE"},
        new string[] { "PLOPPERS", "POGGERS", "PUSS", "PLUMP"},
        new string[] { "RUMPY", "RACISM", "ROWDY", "RUBBER"},
        new string[] { "SUGMA", "SLOPPY", "SUSSY", "SQUEEZY", "SNIFF"},
        new string[] { "TIDDLY", "THICC", "TICKLE", "TESTY", "TWITCHY"},
        new string[] { "UGLY", "UWU", "UGANDAN", "UNDERTALE"},
        new string[] { "VIBIN", "VEINY", "VORE", "VOLUPTUOUS"},
        new string[] { "WIBBLE", "WHIZZIE", "WHOOPIE", "WONKY", "WINCY"},
        new string[] { "YIPPEE", "YOINK", "YOWZERS", "YIKES"},
        new string[] { "ZOINKS", "ZAMN", "ZIPPY"}
    };
    private readonly string[] questions = new string[34]
    {
        "LISTENING SOUND HAS CODE ",
        "CRAZY TALK PHRASE HAS ACTION ",
        "HTTP RESPONSE STATUS HAS RESPONSE ",
        "CHESS RULE DETERMINES THE PIECE AT THE ",
        "ICE CREAM FLAVOUR ",
        "IPHONE IMAGE HAS PIN DIGIT ",
        "DR DOCTOR ",
        "SKYRIM ENEMY IS MOST SUSCEPTIBLE TO ",
        "MORTAL KOMBAT ",
        "MAINTENANCE JOB COSTS £",
        "JUKEBOX SONG HAS THE LYRIC \"",
        "EUROPEAN TRAVEL CITY IN THE UK IS THE ",
        "FONT SELECT TYPEFACE APPEARS ",
        "SUBWAYS STOP IS ",
        "COFFEBUCKS DRINK CONTAINS ",
        "HANGOVER CURE INGREDIENT FOLLOWS ",
        "WESTEROS PHRASE IS THE MOTTO OF HOUSE ",
        "MICRO MODULES COMPONENT ",
        "GROCERY STORE ITEM COSTS $",
        "ULTRACUBE FACE IS OBTAINED BY A",
        "STICKY NOTES TASK IS ",
        "MODKIT MODULE HAS EXACTLY THE COMPONENTS: ",
        "BRAWLER DATABASE FACTION DOES ",
        "DACH MAZE STATE SHARES A ",
        "ASSEMBLY CODE FUNCTION IS CARRIED OUT BY ",
        "INGREDIENTS DISH USES THE INGREDIENTS: ",
        "OBJECT SHOWS CONTEST IS ",
        "SILHOUETTES SOLID OCCUPIES CELL ",
        "HOLD UPS MOVE IS THE LAST LISTED ",
        "MISTER SOFTEE ICE CREAM IS ",
        "VARIETY COMPONENT IS ",
        "CHARMS SPELL IS USED FOR ",
        "BOARD WALK PROPERTY IS IMMEDIATELY CLOCKWISE OF ",
        "SIMON SERVES ITEM IS THE "
    };
    private readonly string[][,] jubblies = new string[34][,]
    {
        new string[,] { { "&&&**", "TAXI DISPATCH"}, { "$#$*&", "EXTRACTOR FAN"}, {"#$$**", "TRAIN STATION" }, { "##*$*", "SOCCER MATCH"}, { "$#*$&", "TAWNY OWL"}, { "#&&*#", "SEWING MACHINE"}, { "**#**", "THRUSH NIGHTINGALE"}, { "&#**&", "CAR ENGINE" }, { "&$$&*", "PHONE RINGING"}, { "#&&&&", "TIBETAN NUNS"}, {"**$$$", "THROAT SINGING"}, { "*#&*&", "DIAL UP INTERNET"}, {"**###", "POLICE RADIO SCANNER"}, { "&&$&*", "CENSORSHIP BLEEP"}, { "&$**&", "MEDIEVAL WEAPONS"}, { "#$#&$", "DOOR CLOSING"}, { "$$*$*", "COMPRESSED AIR"}, { "$&#$$", "SERVO MOTOR"}, { "$&&*&", "TEARING FABRIC"}, { "#&$*&", "VACUUM CLEANER"}, { "$*$**", "BALLPOINT PEN WRITING"}, { "*#$&&", "RATTLING IRON CHAIN"}, { "###&$", "BOOK PAGE TURNING"}, { "*$$&$", "TABLE TENNIS"}, { "$*&##", "SQUEAKY TOY"}, { "$&$$*", "FIREWORK EXPLODING"}, { "*$*$*", "GLASS SHATTERING"} },
        new string[,] { { "1/5", "LITERALLY BLANK"}, { "1/4", "LITERALLY NOTHING"}, { "2/5", "NO LITERALLY NOTHING"}, { "7/0", "THE WORD LEFT"}, { "3/9", "ONE THREE TO FOUR"}, { "5/2", "NO REALLY"}, { "7/6", "STOP TWICE"}, { "8/2", "PERIOS PERIOD"}, { "2/3", "ITS SHOWING NOTHING"}, { "5/1", "NO REALLY STOP"}, { "8/3", "PERIOS TWICE"}, { "1/6", "THERES NOTHING"}, { "7/5", "STOP STOP"}, { "2/4", "NO COMMA LETERALLY NOTHING"}, { "9/4", "THE WORD STOP TWICE"}, { "9/2", "THE PUNCTUATION FULLSTOP"}, { "8/6", "DOT DOT"}, { "6/8", "LEFT ARROW"}, { "6/4", "LEFT ARROW SYMBOL"}, { "6/2", "AN ACTUAL LEFT ARROW"}, { "0/1", "THE WORD BLANK"}, { "8/4", "FULLSTOP FULLSTOP"} },
        new string[,] { { "101", "SWITCHING PROTOCOLS"}, { "301", "MOVED PERMANENTLY"}, { "304", "NOT MODIFIED"}, { "305", "USE PROXY"}, { "400", "BAD REQUEST"}, { "402", "PAYMENT REQUIRED"}, { "404", "NOT FOUND"}, { "408", "REQUEST TIME OUT"}, { "418", "IM A TEAPOT"}, { "500", "INTERNAL SERVER ERROR"}, { "502", "BAD GATEWAY"}, { "503", "SERVICE UNAVAILABLE"} },
        new string[,] { { "FIRST POSITION", "MONARCHY VS THEOCRACY"}, { "SECOND POSITION", "COMMANDER OF THE ARMY"}, { "THIRD POSITION", "A MATTER OF REGENTS"}, { "FOURTH POSITION", "THE IRON TOWER"} },
        new string[,] { { "CONTAINS BANANA", "TUTTI FRUTTI"}, { "IS FIRST ON THE LAST FLAVOUR LIST", "DOUBLE STRAWBERRY"}, { "IS FIRST ON THE FIRST FLAVOUR LIST", "COOKIES AND CREAM"}, { "CONTAINS NUTS", "ROCKY ROAD"}, { "IS FIRST ON THE SECOND FLAVOUR LIST", "DOUBLE CHOCOLATE"}, { "IS SECOND LAST ON THE FIRST FLAVOUR LIST", "RASPBERRY RIPPLE"}, { "IS SECOND LAST ON THE LAST FLAVOUR LIST", "MINT CHOCOLATE CHIP"} },
        new string[,] { { "1", "BHRISTMAS TREE"}, { "7", "FOOTBALL TEAM"}, { "9", "ROAST DINNER"} },
        new string[,] { { "DISEASE CAN BE TREATED WITH TEARS OF TAR", "COLOR ALLERGY"}, { "DISEASE CAN BE TREATED WITH FORTINITE", "FOOT AND MORSE"}, { "DISEASE CAN BE TREATED WITH SCRAPMECHANOL", "GOUT OF LIFE"}, { "DISEASE CAN BE TREATED WITH CRUSHED CANDY", "KEYPAD STONES"}, { "DISEASE CAN BE TREATED WITH WARCRAFTAZOL", "ROYAL FLU"}, { "DISEASE CAN BE TREATED WITH LEEGA LEDGINS", "SEIZURE SIPHOR"}, { "DISEASE CAN BE TREATED WITH ASSASSINE CREAM", "URINARY LEDS"}, { "DISEASE CAN BE TREATED WITH WAR-MED", "YES NO INFECTION"}, { "DISEASE CAN BE TREATED WITH RED DED", "CHRONIC TALK"}, { "DISEASE CAN BE TREATED WITH WALDOHOL", "PERSPECTIVE LOSS"}, { "DISEASE CAN BE TREATED WITH TETRISINE", "HUNTINGTONS DISEASE"}, { "TREATMENT CAN BE USED TO CURE BRAINTENANCE", "GR THETA AUTAZINE"}, { "TREATMENT CAN BE USED TO CURE COLOR ALLERGY", "TEARS OF TAR" }, { "TREATMENT CAN BE USED TO CURE KEYPAD STONES", "CRUSHED CANDY"}, { "TREATMENT CAN BE USED TO CURE NARCOLIZATION", "VITAMIN WII" }, { "TREATMENT CAN BE USED TO CURE TETRINUS", "NO MERCY"}, { "TREATMENT CAN BE USED TO CURE URINARY LEDS", "ASSASSINE CREAM"}, { "TREATMENT CAN BE USED TO CURE WIDGETING", "GLA DOZE"}, { "TREATMENT CAN BE USED TO CURE XMAS", "BALL OF COOTIE"}, { "TREATMENT CAN BE USED TO CURE YES NO INFECTION", "WAR MED"}, { "TREATMENT CAN BE USED TO CURE ZOOTIES", "CS GO LOTION"}, { "TREATMENT CAN BE USED TO CURE CHRONIC TALK", "RED DED"}, { "TREATMENT CAN BE USED TO CURE JUKEPOX", "SOLID GEAR METAL"}, { "TREATMENT CAN BE USED TO CURE NEUROLYSIS", "VITAMIN BEAM"} },
        new string[,] { { "FIRINIEL'S END", "DRAGON PRIEST"}, { "THE VOLENDRUNG", "FROST TROLL"}, { "WINDSHEAR", "DRAUGR OVERLORD"}, { "THE AXE OF WHITERUN", "CAVE BEAR"}, { "THE BLADE OF WOE", "BLOOD DRAGON"} },
        new string[,] { { "CHARACTER USES THE FATALITY \"DEADLY UPPERCUT\"", "JOHNNY CAGE"}, { "CHARACTER USES THE FATALITY \"DRAGON'S BITE\"", "LIU KANG"}, { "CHARACTER USES THE FATALITY \"FIRE KISS\"", "SONYA BLADE"}, { "MOVE HAS THE COMMAND: LEFT RIGHT A", "GREEN FIREBALL"}, { "MOVE HAS THE COMMAND: LEFT RIGHT B", "SHADOW KICK"}, { "MOVE HAS THE COMMAND: DOWN DOWN C", "NUT CRACKER"}, { "MOVE HAS THE COMMAND: RIGHT RIGHT B", "KNIFE THROW" }, { "MOVE HAS THE COMMAND: RIGHT RIGHT C", "DRAGON FIRE"}, { "MOVE HAS THE COMMAND: RIGHT UP A", "FLYING DRAGON KICK"}, { "MOVE HAS THE COMMAND: LEFT LEFT B", "LIGHTNING BOLT"}, { "MOVE HAS THE COMMAND: LEFT RIGHT C", "TELEPORT PUNCH"}, { "MOVE HAS THE COMMAND: UP RIGHT A", "ENERGY RINGS"}, { "MOVE HAS THE COMMAND: DOWN RIGHT C", "LEG GRAB"}, { "MOVE HAS THE COMMAND: RIGHT LEFT B", "SQUARE WAVE PUNCH"}, { "MOVE HAS THE COMMAND: RIGHT UP B", "ICE FREEZE"}, { "MOVE HAS THE COMMAND: RIGHT DOWN C", "GROUND FREEZE"} },
        new string[,] { { "6", "HEADLIGHT BULB"}, { "10", "WIPER REPLACEMANT"}, { "15", "OIL CHANGE"}, { "25", "BRAKE FLUID CHANGE"}, { "40", "WINDSCREEN CHIP"}, { "80", "ONE TYRE"}, { "150", "WINDSCREEN REPLACEMENT"}, { "160", "TWO TYRES"}, { "320", "FOUR TYRES"}, { "500", "EXHAUST WELDING"}, { "750", "HEAD GASKET REPLACEMENT"} },
        new string[,] { { "ALL THIS AGGRAVATION AND SATISFACTION IN ME\"", "A LITTLE LESS CONVERSATION"}, { "YOUR RIDE, BEST TRIP\"", "ALL THE SMALL THINGS"}, { "IF I LEAVE HERE TOMORROW WILL YOU STILL REMEMBER ME\"", "FREE BIRD"}, { "I DON'T CARE IF MONDAY'S BLUE\"", "FRIDAY IM IN LOVE"}, { "THER'S A HOLE IN YOUR LOGIC\"", "GOODBYE MR A"}, { "AND THIS PLACE COULD BE MUCH BRIGHTER THAN TOMORROW\"", "HEAL THE WORLD" }, { "SIT DOWN, IT'S JUST A TALK\"", "HOW TO SAVE A LIFE"}, { "THE MOST BEAUTIFUL THING YOU COULD EVER SPEND\"", "OH MY GOD"}, { "I'VE CROSSED THE DESERTS FOR MILES\"", "PURE SHORES"}, { "I NEED THAT DARK IN A LITTLE MORE LIGHT\"", "SAVE ROCK AND ROLL"}, { "I'M GIVING UP ON YOU\"", "SAY SOMETHING"}, { "I DON'T KNOW WHAT TO SAY, I'LL SAY IT ANYWAY\"", "TAKE ON ME"}, { "WHO KNOWS WHAT TOMORROW BRINGS IN A WORLD FEW HEARTS SURVIVE\"", "UP WHERE WE BELONG"}, { "AND I CAN HARDLY SPEAK\"", "YOU DONT KNOW ME"} },
        new string[,] { { "THE DEPARTURE CITY WITH SERIAL NUMBER CHARACTER: M", "STOKE ON TRENT"}, { "THE DEPARTURE CITY WITH SERIAL NUMBER CHARACTER: Q", "WATFORD JUNCTION"}, { "THE DEPARTURE CITY WITH SERIAL NUMBER CHARACTER: W", "PORTSMOUTH HARBOUR"}, { "THE DEPARTURE CITY WITH SERIAL NUMBER CHARACTER: Z", "HEATHROW AIRPORT"}, { "THE DESTINATION CITY WITH SERIAL NUMBER CHARACTER: A", "BRISTOL TEMPLE MEADS"}, { "THE DESTINATION CITY WITH SERIAL NUMBER CHARACTER: D", "PEMBROKE DOCK"}, { "THE DESTINATION CITY WITH SERIAL NUMBER CHARACTER: G", "LONDON ST PANCRAS"}, { "THE DESTINATION CITY WITH SERIAL NUMBER CHARACTER: T", "STOURBRIDGE TOWN"}, { "THE DESTINATION CITY WITH SERIAL NUMBER CHARACTER: Z", "MANCHESTER VICTORIA"} },
        new string[,] { { "FIRST IN THE SAMPLE LIST", "SPECIAL ELITE"}, { "SECOND IN THE SAMPLE LIST", "GOCHI HAND"}, { "THIRD IN THE SAMPLE LIST", "DAY POSTER BLACK"}, { "FOURTH IN THE SAMPLE LIST", "INDIE FLOWER"}, { "FIFTH IN THE SAMPLE LIST", "COMING SOON"}, { "SIXTH IN THE SAMPLE LIST", "ANONYMOUS PRO"}, { "SEVENTH IN THE SAMPLE LIST", "ROCK SALT"}, { "TENTH IN THE SAMPLE LIST", "OSTRICH SANS"} },
        new string[,] { { "FIRST ON ROUTE 9", "GREEN PARK"}, { "SECOND ON ROUTE 9", "PICCADILLY CIRCUS"}, { "THIRD ON ROUTE 9", "LEICESTER SQUARE"}, { "FIRST ON ROUTE 11", "OXFORD CIRCUS"}, { "SECOND ON ROUTE 11", "TOTTENHAM COURT ROAD"}, { "FIRST ON ROUTE 12", "WARREN STREET"}, { "THIRD ON ROUTE 13", "KINGS CROSS ST PANCRAS"}, { "FIRST ON ROUTE 17", "RICHELIEU DROUOT"}, { "SECOND ON ROUTE 17", "GRANDS BOULEVARDS"}, { "THIRD ON ROUTE 17", "BONNE NOUVELLE"}, { "FIRST ON ROUTE 18", "REAUMUR SEBASTOPOL"}, { "FIRST ON ROUTE 20", "PONT NEUF"}, { "SECOND ON ROUTE 20", "PONT MARIE"}, { "THIRD ON ROUTE 20", "SULLY MORLAND"} },
        new string[,] { { "HAZELNUT", "TWIX FRAPPUCCINO"}, { "PASSION ICED TEA", "THE BLUE DRINK"}, { "AFFOGATO SHOTS", "MATCHA AND ESPRESSO FUSION"}, { "WHITE CHOCOLATE", "LIQUID COCAINE"}, { "TOFFEE", "SMORES HOT CHOCOLATE"}, { "STRAWBERRIES", "THE PINK DRINK"}, { "PEPPERMINT", "GRASSHOPPER FRAPPUCCINO"} },
        new string[,] { { "WHITE WINE", "REMORSE AND CONTRITION" }, { "PROSECCO", "HALF A BIG MAC"}, { "RUM", "BLACK COFFEE"}, { "RED WINE", "FAMILY PACK OF OREOS"}, { "SPIRITS AFTER ADDING AVOCADO TOAST", "SLICED APPLE"}, { "NO KEBAB AFTER ADDING SLICED APPLE", "COOKING OIL"}, { "A NON SPIRIT AFTER ADDING 2 RAW EGGS", "BACON CRISPS"}, { "SHOTS AFTER ADDING LARD", "AVOCADO TOAST"}, { "A DONER KEBAB AFTER ADDING AN ENTIRE CAN OF RED BULL", "WHOLE PIZZA"} },
        new string[,] { { "ARRYN", "AS HIGH AS HONOUR"}, { "BARATHEON", "OURS IS THE FURY"}, { "BOLTON", "OUR BLADES ARE SHARP"}, { "CERWYN", "HONED AND READY"}, { "FREY", "WE STAND TOGETHER"}, { "GREYJOY", "WE DO NOT SOW"}, { "HIGHTOWER", "WE LIGHT THE WAY"}, { "HORNWOOD", "RIGHTEOUS IN WRATH"}, { "KARSTARK", "THE SUN OF WINTER"}, { "LANNISTER", "HEAR ME ROAR"}, { "MARBRAND", "BURING BRIGHT"}, { "MARTELL", "UNBOWED UNBENT UNBROKEN"}, {"MORMONT", "HERE WE STAND"}, { "PENROSE", "SET DOWN OUR DEEDS"}, { "ROYCE", "WE REMEMBER"}, { "STARK", "WINTER IS COMING"}, { "TARGARYEN", "FIRE AND BLOOD"}, { "TARLY", "FIRST IN BATTLE"}, { "TULLY", "FAMILY DUTY HONOUR"}, { "TYRELL", "GROWING STRONG"} },
        new string[,] { { "IS INTERACTED WITH LAST", "SOLVE BUTTON"}, { "DISPLAYS CODE ON A SCREEN", "SCRIPT WIRES"}, { "HAS BUTTONS LABELLED WITH ARROWS", "DIRECTIONAL KEYPAD"}, { "HAS SEND AND RECEIVE BUTTONS", "CODE MORSE"}, { "DISPLAYS THREE CHARACTERS", "MATH CODE"}, { "HAS A COOLDOWN", "THE RESET BUTTON"} },
        new string[,] { { "12.48", "BOTTLED WATER"}, { "11.99", "CAT FOOD"}, { "06.28", "GLASS CLEANER"}, { "05.42", "HOT SAUCE"}, { "08.68", "PAPER TOWELS"}, { "05.64", "PEANUT BUTTER"}, { "16.99", "TOILET PAPER"} },
        new string[,] { { "N XY ROTATION", "ZAG TOP RIGHT"}, { "N XZ ROTATION", "TOP BACK RIGHT"}, { "N XW ROTATION", "PONG TOP LEFT"}, { "N XV ROTATION", "BOTTOM BACK RIGHT"}, { " YZ ROTATION", "ZIG TOP BACK"}, { " YW ROTATION", "PONG BACK LEFT"}, { " YV ROTATION", "ZIG FRONT RIGHT"}, { " ZW ROTATION", "PONG ZAG RIGHT"}, { " ZV ROTATION", "PING ZIG BOTTOM"}, { " WV ROTATION", "PING ZAG BACK"} },
        new string[,] { { "FIRST IN THE ADMIN LIST", "PHOTOCOPY MANAGERS SCHEDULE"}, { "SECOND IN THE ADMIN LIST", "MAKE COFFEE FOR VISITORS"}, { "SEVENTH IN THE ADMIN LIST", "BUY TEA AND COFFEE"}, { "LAST IN THE ADMIN LIST", "CHECK TIMESHEETS OF EMPLYEES"}, { "SECOND IN THE HR LIST", "UPDATE NEW STARTER FILE"}, { "THIRD IN THE HR LIST", "CHANGE ADDRESSES OF EMPLOYEES"}, { "FOURTH IN THE HR LIST", "PHOTOCOPY PERSONNEL FILE"}, { "FIFTH IN THE HR LIST", "INTERVIEW NEW STARTERS"}, { "SIXTH IN THE HR LIST", "DISCIPLINARY WITH DAZARINO"}, { "SEVENTH IN THE HR LIST", "CALL NEW APPLICANTS"}, { "EIGHTH IN THE HR LIST", "MEETING WITH VISITORS"}, { "LAST IN THE HR LIST", "UPDATE VEHICLE DATABASE"}, { "FIRST IN THE PAYROLL LIST", "RECONCILE TAX"}, { "SECOND IN THE PAYROLL LIST", "PAY EMPLOYEES"}, { "THIRD IN THE PAYROLL LIST", "PAY OUTSTANDING INVOICES"}, { "FOURTH IN THE PAYROLL LIST", "PAY IN PETTY CASH"}, { "FIFTH IN THE PAYROLL LIST", "CONTACT UNPAID INVOICES"}, { "SIXTH IN THE PAYROLL LIST", "GENERATE PAYSLIPS"}, { "SEVENTH IN THE PAYROLL LIST", "POST NEXT WEEKS INVOICES"}, { "EIGHTH IN THE PAYROLL LIST", "CALL CLIENT FOR MEETING"}, { "LAST IN THE PAYROLL LIST", "DEPOSIT EARNINGS IN BANK"} },
        new string[,] { { "WIRES", "COLORFUL WIRES"}, { "SYMBOLS", "ADJACENT SYMBOLS"}, { "ALPHABET", "EDGEWORK KEYS"}, { "LED", "LED PATTERN"}, { "ARROWS", "SIMON SHIFTS"}, { "WIRES, SYMBOLS", "RUNIC WIRES"}, { "WIRES, ALPHABET", "INDEXED WIRES"}, { "WIRES, LED", "WIRE INSTRUCTIONS"}, { "WIRES, ARROWS", "WIRE MAZE"}, { "SYMBOLS, ALPHABET", "ENCRYPTED KEYPAD"}, { "SYMBOLS, LED", "SYMBOLIC MORSE"}, { "SYMBOLS, ARROWS", "PERSPECTIVE SYMBOLS"}, { "ALPHABET, LED", "SEMAPHORE KEYS"}, { "ALPHABET ARROWS", "ALPHANUMERIC ORDER"}, { "LED, ARROWS", "COLOR COMPASS"}, { "WIRES, SYMBOLS, ALPHABET", "SEQUENCE CUT"}, { "WIRES, SYMBOLS, LED", "HIERARCHICAL WIRES"}, { "WIRES, SYMBOLS, ARROWS", "WIRE SIGNALLING"}, { "WIRES, ALPHABET, LED", "POWER GRID"}, { "WIRES, ALPHABET, ARROWS", "CRUEL WIRE SEQUENCES"}, { "WIRES, LED, ARROWS", "BLINKING WIRES"}, { "SYMBOLS, ALPHABET, LED", "KEY SCORE"}, { "SYMBOLS, ALPHABET, ARROWS", "LYING KEYS"}, { "SYMBOLS, LED, ARROWS", "COLOR OFFSET"}, { "ALPHABET, LED, ARROWS", "LED DIRECTIONS"}, { "WIRES, SYMBOLS, ALPHABET, LED", "THE THIRD WIRE"}, { "WIRES, SYMBOLS, ALPHABET, ARROWS", "THE LAST IN LINE"}, { "WIRES, SYMBOLS, LED, ARROWS", "COLOR DOMINANCE"}, { "WIRES, ALPHABET, LED, ARROWS", "PRECISE WIRES"}, { "SYMBOLS, ALPHABET, LED, ARROWS", "GATED MAZE"}, { "WIRES, SYMBOLS, ALPHABET, LED, ARROWS", "PARANORMAL WIRES"} },
        new string[,] { { "DAN BELONG TO", "BATTLE BRAWLERS"}, { "KAZARINA BELONG TO", "TWELVE ORDERS"}, { "ANUBIAS BELONG TO", "CHAOS ARMY"}, { "MASQUERADE BELONG TO", "DOOM BEINGS"} },
        new string[,] { { "DIAMOND BORDER WITH BAVARIA", "BADEN WURTTEMBURG"}, { "DIAMOND BORDER WITH LOWER SAXONY", "MECKLENBURG VORPOMMERN"}, { "TRIANGLE BORDER WITH HESSE", "LOWER SAXONY"}, { "SQUARE BORDER WITH HESSE", "NORTH RHINE WESTPHALIA"}, { "HEART BORDER WITH SAARLAND", "RHINELAND PALATINATE"}, { "TRAPEZIUM BORDER WITH LOWER SAXONY", "SCHLESWIG HOLSTEIN"}, { "DIAMOND BORDER WITH THURINGIA", "SAXONY ANHALT"}, { "DIAMOND BORDER WITH VIENNA", "LOWER AUSTRIA"}, { "TRIANGLE BORDER WITH SALZBURG", "NORTH TYROL"}, { "TRAPEZIUM BORDER WITH BAVARIA", "UPPER AUSTRIA"}, { "STAR BORDER WITH SALZBURG", "EAST TYROL"}, { "STAR BORDER WITH THURGAU", "APPENZELL OUTER RHODES"}, { "HEART BORDER WITH JURA", "BASEL COUNTRY"} },
        new string[,] { { "ADC", "ADD WITH CARRY"}, { "CLC", "CLEAR CARRY FLAG"}, { "CLD", "CLEAR DIRECTION FLAG"}, { "CLI", "CLEAR INTERRUPTION FLAG"}, { "CMC", "COMPLEMENT CARRY FLAG"}, { "CMP", "COMPARE OPERANDS"}, { "CMPSW", "COMPARE WORDS"}, { "DIV", "UNSIGNED DIVIDE"}, { "HLT", "ENTER HALT STATE"}, { "INT", "CALL TO INTERRUPT"}, { "IRET", "RETURN FROM INTERRUPT"}, { "JCC", "JUMP IF CONDITION"}, { "LEA", "LOAD EFFECTIVE ADDRESS"}, { "LODSB", "LOAD STRING BYTE"}, { "LODSW", "LOAD STRING WORD"}, { "MUL", "UNSIGNED MULTIPLY"}, { "NEG", "TWOS COMPLEMENT NEGATION"}, { "NOP", "NO OPERATION"}, { "RET", "RETURN FROM PROCEDURE"}, { "RETN", "RETURN FROM NEAR PROCEDURE"}, { "RETF", "RETURN FROM FAR PROCEDURE"}, { "SBB", "SUBTRACTION WITH BORROW"}, { "STC", "SET CARRY FLAG"}, { "STD", "SET DIRECTION FLAG"}, { "STI", "SET INTERRUPTION FLAG"}, { "STOSB", "STORE BYTE IN STRING"}, { "STOSW", "STORE WORD IN STRING"}, { "XCHG", "EXCHANGE DATA"}, { "XLAT", "TABLE LOOK UP TRANSLATION"} },
        new string[,] { { "BLACK TRUMPET, CHANTERELLE, KING OYSTER, MOREL", "MUSHROOM TERRINE"}, { "BASIL, CHEESE, STRAWBERRY, TOMATO", "CAPRESE SALAD"}, { "DILL, TOMATO, WATERMELON", "COLD TOMATO SOUP"}, { "BLOOD ORANGE, LOBSTER, OLIVE OIL, SEA BASS", "SEAFOOD TARTARE"}, { "CHANTERELLE, GRAPES, PARSLEY, SEA BASS, ZUCCHINI", "SEA BASS POELE"}, { "LEMON, PORCINI, VEAL", "SWEETBREAD POELE"}, { "BEEF, CORNICHON, EGGPLANT, ZUCCHINI", "BEEF SAUTE"}, { "BUTTER, CHOCOLATE, LEMON", "CHOCOLATE MOUSSE"}, { "APPLE, APRICOT, PEAR", "FRESH FRUIT COMPOTE"}, { "BUTTER, HONEY, ORANGE", "CREPES SUZETTE"}, { "BLACKBERRY, CHEESE, GOOSEBERRY, LEMON, RASPBERRY", "BERRIES AU FROMAGE"}, { "BANANA, BUTTER, HONEY", "WARM BANANA SOUFFLE"}, { "GOOSEBERRY, MELON, PEAR", "FRUIT GELEE"}, { "BANANA, BLOOD ORANGE, GRAPES, MELON, SOUR CHERRY, STRAWBERRY, WATERMELON", "TARTE AUX FRUITS"} },
        new string[,] { { "CREATIVE TYPE AND WATER STYLE", "UNDERWATER BASKET WEAVING"}, { "BATTLE TYPE AND WATER STYLE", "WATER BALLOON FIGHT"}, { "ATHLETIC TYPE AND WATER STYLE", "CAVE DIVING"}, { "RACE TYPE AND STADIUM STYLE", "CHARIOT RACE"}, { "CREATIVE TYPE AND STADIUM STYLE", "EQUESTRAIN ACROBATICS"}, { "BATTLE TYPE AND STADIUM STYLE", "GLADITORIAL FIGHT"}, { "ATHLETIC TYPE AND STADIUM STYLE", "THE OBJECTIVE GAMES"}, { "RACE TYPE AND WILD STYLE", "ESCAPE THE VOLCANO"}, { "CREATIVE TYPE AND WILD STYLE", "JUNGLE SURVIVAL"}, { "BATTLE TYPE AND WILD STYLE", "TIGER TAMING"}, { "ATHLETIC TYPE AND WILD STYLE", "CLIFF CLIMBING"}, { "RACE TYPE AND WEIRD STYLE", "SACK RACE"}, { "CREATIVE TYPE AND WEIRD STYLE", "INETPRETIVE DANCE"}, { "BATTLE TYPE AND WEIRD STYLE", "NOSE NABBING"} },
        new string[,] { { "A4", "ANNULAR CYLINDER"}, { "A7", "BILINSKI DODECAHEDRON"}, { "B1", "CIRCULAR FRUSTUM"}, { "B3", "DELTOIDAL ICOSITETRAHEDRON"}, { "C1", "HEXAGONAL PRISM"}, { "C2", "HYPERBOLIC BICYLINDER"}, { "C3", "HYPERBOLIC CYLINDER"}, { "C7", "DOUBLE HYPERBOLIC CYLINDER"}, { "C8", "ELONGATED BICONE"}, { "D3", "NAPKIN RING"}, { "D4", "OBLATE SPHEROID"}, { "D6", "ORTHOGONAL TRICYLINDER"}, { "D7", "PENTAGONAL ANTIPRISM"}, { "D8", "PENTAGONAL BIPYRAMID"}, { "E1", "PENTAGONAL PRISM"}, { "E3", "PLANAR TRICYLINDER"}, { "E4", "PROLATE SPHEROID"}, { "E7", "REULEAUX CONE"}, { "E8", "REULEAUX TETRAHEDRON"}, { "F1", "REULEAUX TRIANGULAR PRISM"}, { "F2", "RHOMBIC DODECAHEDRON"}, { "F3", "RHOMBIC ICOSAHEDRON"}, { "F4", "RHOMBIC TRIACONTAHEDRON"}, { "G1", "SNUB DISPHENOID"}, { "G2", "SPHERICAL CONE"}, { "G3", "SPHERICAL SQUARE PYRAMID"}, { "G5", "SPHERICAL WEDGE"}, { "G6", "SQUARE ANTIPRISM"}, { "G7", "SQUARE FRUSTUM"}, { "H5", "TRIANGULAR BIPYRAMIND"}, { "H6", "TRIANGULAR PRISM"} },
        new string[,] { { "FIRE TYPE MOVE", "BLAZING HELL"}, { "ICE TYPE MOVE", "ICE AGE"}, { "ELEC TYPE MOVE", "WILD THUNDER"}, { "WIND TYPE MOVE", "VACUUM WAVE"}, { "NUCLEAR TYPE MOVE", "COSMIC FLARE"}, { "PSY TYPE MOVE", "PSYCHO BLAST"}, { "BLESS TYPE MOVE", "SHINING ARROWS"}, { "CURSE TYPE MOVE", "ABYSSAL WINGS"}, { "GUN TYPE MOVE", "RIOT GUN"} },
        new string[,] { { "ALYSSA'S FAVOURITE", "STRAWBERRY SHORTCAKE"}, { "BOBBY'S FAVOURITE", "SNOW CONE"}, { "CLARISSA'S FAVOURITE", "ICE CREAM SANDWICH"}, { "DAVID'S FAVOURITE", "KING CONE"}, { "GEORGE'S FAVOURITE", "CHOCO TACO"}, { "HUNTER'S FAVOURITE", "BANANA FUDGE BOMB"}, { "ISABELLA'S FAVOURITE", "CHOCOLATE ECLAIR"}, { "KYLE'S FAVOURITE", "SCREW BALL"}, { "LILY'S FAVOURITE", "PUSH UP POP"}, { "BOBBY'S SECOND FAVOURITE", "FUDGE POP"}, { "EVERYBODY'S LEAST FAVOURITE", "SPONGEBOB BAR"} },
        new string[,] { { "FIRST ITEM ON THE LIST", "VERTCAL SLIDER"}, { "SECOND ITEM ON THE LIST", "YELLOW KEYPAD"}, { "FOURTH ITEM ON THE LIST", "YELLOW WIRE"}, { "FIFTH ITEM ON THE LIST", "BLUE KEYPAD"}, { "SIXTH ITEM ON THE LIST", "BRAILLE DISPLAY"}, { "EIGHTH ITEM ON THE LIST", "RED SWITCH"}, { "TWELFTH ITEM ON THE LIST", "BLUE WIRE"}, { "THIRTEENTH ITEM ON THE LIST", "HORIZONTAL SLIDER"}, { "FOURTEENTH ITEM ON THE LIST", "RED KEYPAD"}, { "SIXTEENTH ITEM ON THE LIST", "RED WIRE"}, { "EIGHTEENTH ITEM ON THE LIST", "BLUE BUTTON"}, { "NINTEENTH ITEM ON THE LIST", "YELLOW BUTTON"}, { "TWENTIETH ITEM ON THE LIST", "KEY IN LOCK"}, { "TWENTY-FIRST ITEM ON THE LIST", "DIGIT DISPLAY"}, { "TWENTY-SECOND ITEM ON THE LIST", "WHITE BUTTON"}, { "TWENTY-FOURTH ITEM ON THE LIST", "RED BUTTON"}, { "TWENTY-FIFTH ITEM ON THE LIST", "BLUE SWITCH"}, { "TWENTY-SIXTH ITEM ON THE LIST", "WHITE WIRE"}, { "TWENTY-NINETH ITEM ON LIST", "LETTER DISPLAY"}, { "THIRTIETH ITEM ON THE LIST", "YELLOW SWITCH"}, { "THIRTY-FIRST ITEM ON THE LIST", "WHITE SWITCH"}, { "THIRTY-SECOND ITEM ON THE LIST", "BLACK WIRE"} },
        new string[,] { { "TRAIN SUMMONING", "CONFORMARE SERIES"}, { "UNCOVERING ANIMAL TRACKS", "VESTIGIUM OSTENDARE"}, { "CATCHING FISH", "AENIGMA INSULSUS"}, { "AN ADVENTURE GAME POTION ALTERNATIVE", "FORTIS FACINI"}, { "PRONOUN THEFT", "ID ISEA"}, { "NUMERIC SQUEEZING", "ARIERAE FACTURA"}, { "INTERACTING WITH BIRDS", "FULICES TERREAT"}, { "FLAVOURING DESSERTS", "POMI AMBROSIA"}, { "SETTLEMENT CONSTRUCTION", "URBS CRUMINIS"}, { "PLANT IDENTIFICATION", "MORTUOS DEFENDISSE"}, { "COMPUTER HACKING", "INCURRERE MACHINATIONES"}, { "RAIN SUMMONING", "PLUVIARUM VERSICOLORIUM"}, { "HIGHER DIMENSIONAL GEOMETRY GENERATION", "TESSELLAM ADCESSIO"}, { "CREATING LIFE", "SICUT PATER"}, { "CURSING DOUBLE-OH", "VENDICARE COMPOSITUM"}, { "GHOST BANISHMENT", "SPECULI EXPIATIO"}, { "INTERACTING WITH TRAINGLES", "PRAESTIGIATOR FABARUM"}, { "M SUMMONING", "SILENTIUM COELI"}, { "NEEDLE THREADING", "DAEDALAE ORBITAE"}, { "NETHERITE MINING", "VASTATOR METALLIS TESQUORUM"} },
        new string[,] { { "GO", "MEDITERRANEAN AVENUE"}, { "READING RAILROAD", "ORIENTAL AVENUE"}, { "JAIL", "ST CHARLES PLACE"}, { "THE ELECTRIC COMPANY", "STATES AVENUE"}, { "PENNSYLVANIA RAILROAD", "ST JAMES PLACE"}, { "FREE PARKING", "KENTUCKY AVENUE"}, { "B&O RAILROAD", "ATLANTIC AVENUE"}, { "WATER WORKS", "MARVIN GARDENS"}, { "GO TO JAIL", "PACIFIC AVENUE"} },
        new string[,] { { "RED DRINK", "CRUELO JUICE"}, { "WHITE DRINK", "DEFUSE JUICE"}, { "BLUE DRINK", "SIMONS SPECIAL MIX"}, { "BROWN DRINK", "BOOM LAGER BEER"}, { "GREEN DRINK", "FORGET COCKTAIL"}, { "YELLOW DRINK", "WIRE SHAKE"}, { "ORANGE DRINK", "DETO BULL"}, { "PINK DRINK", "TASHAS DRINK"}, { "RED APPETIZER", "CAESAR SALAD"}, { "WHITE APPETIZER", "EDGEWORK TOAST"}, { "BLUE APPEIZER", "TICKING TIMECAKES"}, { "BROWN APPETIZER", "BIG BOOM TORTELLINI"}, { "GREEN APPETIZER", "STATUS LIGHT ROLLS"}, { "YELLOW APPETIZER", "BLAST SHRIMPS"}, { "ORANGE APPETIZER", "MORSE SOUP"}, { "PINK APPETIZER", "BOOLEAN WAFFLES"}, { "RED MAIN COURSE", "FORGHETTI BOMBOGNESE"}, { "WHITE MAIN COURSE", "NATO SHRIMPS"}, { "BLUE MAIN COURSE", "WIRE SPAGHETTI"}, { "BROWN MAIN COURSE", "INDICATOR TAR TAR"}, { "GREEN MAIN COURSE", "CENTURION WINGS"}, { "YELLOW MAIN COURSE", "COLORED SPARE RIBS"}, { "ORANGE MAIN COURSE", "OMELETTE AU BOMBAGE"}, { "PINK MAIN COURSE", "VEGGIE BLAST PLATE"}, { "RED DESSERT", "STRIKE PIE"}, { "WHITE DESSERT", "BLASTWAVE COMPOTE"}, { "BLUE DESSERT", "NOT ICE CREAM"}, { "BROWN DESSERT", "DEFUSE AU CHOCOLAT"}, { "GREEN DESSERT", "SOLVE CAKE"}, { "YELLOW DESSERT", "BAKED BATTERYS"}, { "ORANGE DESSERT", "BAMBOOZLING WAFFLES"}, { "PINK DESSERT", "BOMB BRULEE"} }
    };
    private readonly string[] exceptions = new string[] { "THE", "A", "OF", "AU", "AUX", "AN", "AND", "IS"};
    private IEnumerator cycle;
    private string[] subselect = new string[9];
    private string subinits;
    private string[] qselect = new string[3];
    private string[,] aselect = new string[3, 2];
    private string submission;
    private int stage;
    private bool gameon;

    private static int moduleIDCounter;
    private int moduleID;
    private bool moduleSolved;

    private void Start()
    {
        moduleID = ++moduleIDCounter;
        int[] rand = Enumerable.Range(0, 24).ToArray().Shuffle().ToArray();
        for (int i = 0; i < 9; i++)
        {
            subselect[i] = subblies[rand[i]].PickRandom();
            subinits += subselect[i][0].ToString();
        }
        cycle = Cycle();
        StartCoroutine(cycle);
        Debug.LogFormat("[Subbly Jubbly #{0}] The list of words to substitute into the answers is: {1}", moduleID, string.Join(", ", subselect));
        foreach(KMSelectable button in buttons)
        {
            int b = buttons.IndexOf(button);
            button.OnInteract = delegate ()
            {
                if (!moduleSolved)
                {
                    switch (b)
                    {
                        case 0:
                            if (!gameon)
                            {
                                gameon = true;
                                StopCoroutine(cycle);
                                displays[2].text = "GOOD LUCK";
                                StartCoroutine(Flip(false));
                                Audio.PlaySoundAtTransform("Start", transform);
                                buttondown.localPosition += new Vector3(0, 20, 0);
                                button.AddInteractionPunch();
                                Audio.PlayGameSoundAtTransform(KMSoundOverride.SoundEffect.BigButtonRelease, buttondown);
                            }
                            break;
                        case 1:
                            if (gameon && submission.Length > 0)
                            {
                                button.AddInteractionPunch(0.6f);
                                Audio.PlayGameSoundAtTransform(KMSoundOverride.SoundEffect.ButtonPress, button.transform);
                                if (submission.Length > 0)
                                    submission = submission.Remove(submission.Length - 1);
                                qa[1].text = submission;
                            }
                            break;
                        case 2:
                            if(gameon && submission.Length > 0)
                            {
                                button.AddInteractionPunch(0.6f);
                                Audio.PlayGameSoundAtTransform(KMSoundOverride.SoundEffect.ButtonPress, button.transform);
                                if (submission.Last() != ' ')
                                {
                                    submission += " ";
                                    qa[1].text += " ";
                                }
                            }
                            break;
                        case 3:
                            if(gameon && submission.Length > 0)
                            {
                                button.AddInteractionPunch(0.6f);
                                Audio.PlayGameSoundAtTransform(KMSoundOverride.SoundEffect.ButtonPress, button.transform);
                                if(submission.Last() == ' ')
                                    submission = submission.Remove(submission.Length - 1);
                                Debug.LogFormat("[Subbly Jubbly #{0}] Submitted {1}.", moduleID, submission);
                                if(submission == aselect[stage, 1])
                                {
                                    Audio.PlaySoundAtTransform("InputCorrect", transform);
                                    stage++;
                                    if(stage > 2)
                                    {
                                        qa[0].text = "";
                                        displays[0].text = "";
                                        displays[1].text = "GG";
                                        moduleSolved = true;
                                        Audio.PlaySoundAtTransform("Solve", transform);
                                        StartCoroutine(Congratulations());
                                        module.HandlePass();
                                        StartCoroutine(Flip(true));
                                    }
                                    else
                                    {
                                        displays[0].text = (stage + 1).ToString();
                                        submission = "";
                                        qa[1].text = "";
                                        qa[0].text = qselect[stage];
                                        QLog(stage);
                                    }
                                }
                                else
                                {
                                    module.HandleStrike();
                                    Audio.PlaySoundAtTransform("Strike", transform);
                                    StartCoroutine(Flip(true));
                                    StartCoroutine(cycle);
                                    submission = "";
                                    qa[0].text = "";
                                    qa[1].text = "";
                                    displays[0].text = "";
                                    displays[1].text = "";
                                }
                            }
                            break;
                        default:
                            if (gameon)
                            {
                                button.AddInteractionPunch(0.3f);
                                Audio.PlaySoundAtTransform("Click", button.transform);
                                string k = "QWERTYUIOPASDFGHJKLZXCVBNM"[b - 4].ToString();
                                qa[1].text += k;
                                submission += k;
                            }
                            break;
                    }
                }
                return false;
            };
        }
    }

    private IEnumerator Cycle()
    {
        int i = 0;
        while (!moduleSolved)
        {
            displays[2].text = subselect[i];
            yield return new WaitForSeconds(0.8f);
            displays[2].text = "";
            yield return new WaitForSeconds(0.2f);
            i += 1;
            i %= 9;
        }
    }

    private IEnumerator Flip(bool b)
    {
        StopCoroutine("Countdown");
        Audio.PlaySoundAtTransform("Flip", transform);
        board[b ? 1 : 2].SetActive(true);
        float e = 0;
        while(e < 180)
        {
            float d = Time.deltaTime;
            e += 60 * d;
            board[0].transform.Rotate(0, 0, 60 * d);
            yield return null;
        }
        if (b)
        {
            board[0].transform.localEulerAngles = new Vector3(0, 0, 0);
            if (!moduleSolved)
            {
                gameon = false;
                buttondown.localPosition -= new Vector3(0, 20, 0);
            }
            board[2].SetActive(false);
            displays[0].text = "";
            displays[1].text = "";
        }
        else
        {
            board[0].transform.localEulerAngles = new Vector3(0, 0, 180);
            board[1].SetActive(false);
            stage = 0;
            int[] rand = Enumerable.Range(0, 34).ToArray().Shuffle().ToArray();
            int k = -1;
            for (int i = 0; i < 3; i++)
            {
                bool exists = false;
                while (!exists)
                {
                    k++;
                    int q = jubblies[rand[k]].Length / 2;
                    int[] testorder = Enumerable.Range(0, q).ToArray().Shuffle().ToArray();
                    for(int j = 0; j < q; j++)
                    {
                        int p = testorder[j];
                        string[] a = jubblies[rand[k]][p, 1].Split(' ');
                        if (subinits.Any(x => a.Where(z => !exceptions.Contains(z)).Select(z => z[0].ToString()).Contains(x.ToString())))
                        {
                            qselect[i] = "WHICH " + questions[rand[k]] + jubblies[rand[k]][p, 0] + "?";
                            aselect[i, 0] = a.Join();
                            aselect[i, 1] = Substitute(a);
                            exists = true;
                            break;
                        }
                    }
                }
            }
            qa[0].text = qselect[0];
            displays[0].text = "1";
            displays[1].text = "180";
            StartCoroutine("Countdown");
            QLog(0);
        }
    }

    private IEnumerator Countdown()
    {
        for(int i = 180; i > 0; i--)
        {
            displays[1].text = i.ToString();
            yield return new WaitForSeconds(1);
        }
        displays[1].text = "0";
        module.HandleStrike();
        gameon = false;
        qa[0].text = "";
        qa[1].text = "";
        Debug.LogFormat("[Subbly Jubbly #{0}] Out of time.", moduleID);
        StartCoroutine(Flip(false));
    }

    private string Substitute(string[] a)
    {
        string[] x = new string[a.Length];
        for(int i = 0; i < a.Length; i++)
        {
            if (!exceptions.Contains(a[i]))
            {
                for (int j = 0; j < 9; j++)
                {
                    if (!x.Contains(subselect[j]) && subselect[j][0] == a[i][0])
                    {
                        x[i] = subselect[j];
                        goto done;
                    }
                }
            }
            x[i] = a[i];
        done:;
        }
        return x.Join();
    }

    private void QLog(int s)
    {
        Debug.LogFormat("[Subbly Jubbly #{0}] Question {1}: {2}", moduleID, s + 1, qselect[s]);
        Debug.LogFormat("[Subbly Jubbly #{0}] Answer: {1}", moduleID, aselect[s, 0]);
        Debug.LogFormat("[Subbly Jubbly #{0}] Expectation: {1}", moduleID, aselect[s, 1]);
    }

    private IEnumerator Congratulations()
    {
        string[] suffixes = new string[12] { "OOGLY", "UMPY", "UNKY", "UBBLY", "OMBUS", "OBBY", "ITTERY", "UMBLE", "UZZLE", "AWPY", "IGGLY", "ANGLY" };
        while (moduleSolved)
        {
            int r = Random.Range(0, 13);
            if (r > 9)
            {
                displays[2].text = "GOOD JOB";
                yield return new WaitForSeconds(0.625f);
            }
            else
            {
                displays[2].text = "G" + suffixes[r] + " J" + suffixes[r];
                yield return new WaitForSeconds(0.125f);
            }
        }
    }
#pragma warning disable 414
    private readonly string TwitchHelpMessage = "!{0} start [Presses button] | !{0} enter <A-Z > [Enters command into module, including spaces] | !{0} delete # [Removes the last # characters from the entry] | !{0} submit";
#pragma warning restore 414

    private IEnumerator ProcessTwitchCommand(string command)
    {
        string[] c = command.ToUpperInvariant().Split(' ');
        yield return null;
        if(c[0] == "ENTER")
        {
            string message = c.Skip(1).Join();
            for(int i = 0; i < message.Length; i++)
            {
                if (message[i] == ' ')
                    buttons[2].OnInteract();
                else
                {
                    int q = "QWERTYUIOPASDFGHJKLZXCVBNM".IndexOf(message[i].ToString());
                    if(q < 0)
                    {
                        yield return "sendtochaterror!f " + message[i] + " is not a letter or a space";
                        yield break;
                    }
                    buttons[q + 4].OnInteract();
                }
                yield return new WaitForSeconds(0.125f);
            }
        }
        else if(c[0] == "DELETE")
        {
            if(c.Length > 2)
            {
                yield return "sendtochaterror!f Invalid delete command length.";
                yield break;
            }
            int d;
            if (int.TryParse(c[1], out d))
            {
                for(int i = 0; i < d; i++)
                {
                    if (submission.Length > 0)
                        yield break;
                    buttons[1].OnInteract();
                    yield return null;
                }
            }
            else
                yield return "sendtochaterror!f " + c[1] + " is not a number.";

        }
        else if(c[0] == "SUBMIT")
        {
            buttons[3].OnInteract();
        }
        else if (c[0] == "START")
        {
            buttons[0].OnInteract();
        }
        else
        {
            yield return "sendtochaterror!f " + command + " is an invalid command.";
        }
    }
}
