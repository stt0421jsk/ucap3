// PROJECT TITLE >> UCPA3
// DEVELOPER >> Joonsung Kim(stt0421-jsk)
// PROJECT START DATE >> Feb 20, 2022
// CURRENT VERSION >> 0.0.1
// CURRENT STATE >> IN DEVELOPMENT

using System;
using System.IO;
using System.Collections.Generic;
namespace CSC3
{
    class Program
    {
        public static string[] v_login_idlist;
        public static string[] v_login_pwlist;
        public static int v_login_pwIndex;
        public static string v_main_id;
        public static string[] v_selectType_typeList = {"CMD", "WEB", "CLC", "CNV", "LOG"};
        public static string v_typeCnv_userInput;
        public static string[] v_typeCnv_userInputList;
        public static string v_determineType_type;
        public static string v_getSubjective_subjective;
        public static string v_getSubjective_subjectiveGeneral;
        public static string[] v_global_articleList = {"A", "An", "The", "a", "an", "the"};
        public static string[] v_global_greetingList = {"hi", "Hi", "Hello", "hello", "Hi,", "hi,", "hello,", "Hello,", "hi!", "Hi!", "Hello!", "hello!"};
        public static string[] v_global_positiveList = {"y", "Y", "Yes", "yes", "yeah", "sure", "yep", "yup", "ok", "okay", "k", "Okay", "dd", "ya", "yas"};
        public static string[] v_global_negativeList = {"n", "N", "No", "no", "nope", "not really", "Nope", "Not really", "nah", "Nah", "ss", "na"};
        public static string[] v_global_meList = {"me", "i", "I", "Me", "I'll", "I'd", "I've", "I'm"};
        public static string[] v_global_youList = {"you", "You", "Chatbot", "chatbot", "thee", "thy", "tu", "you'd", "you've", "You'd", "You've", "You're", "you're", "your", "Your"};
        public static string[] v_global_heList = {"he", "his", "He", "His", "He's", "He've", "He'd"};
        public static string[] v_global_sheList = {"she", "her", "She", "Her", "she's", "she've", "she'd"};
        public static string[] v_global_theyList = {"they", "their", "They", "Their", "They're", "They've", "They'd"};
        public static string[] v_global_beList = {"am", "are", "is", "was", "were", "be", "been"};
        public static void f_greeting() {
            Console.WriteLine();
            Console.WriteLine("Project >> CSC3");
            Console.WriteLine("Dev >> Joonsung Kim");
            Console.WriteLine("Date/Version >> Feb 20 2022, VI.1.1");
            Console.WriteLine();
        }
        public static void f_selectLogin() {
            Console.WriteLine("f_selectLogin() >> [1] Registered User    [2] New User");
            Console.Write("f_selectLogin() >> ");
            string v_selectLogin_userInput = Console.ReadLine();
            if (v_selectLogin_userInput == "1") {
                Console.WriteLine();
                Console.WriteLine("f_selectLogin() >> WELCOME BACK TO CSC3");
                Console.WriteLine();
                f_login();
            }
            else if (v_selectLogin_userInput == "2") {
                Console.WriteLine();
                Console.WriteLine("f_selectLogin() >> REGISTER A NEW ACCOUNT");
                Console.WriteLine();
                f_register();
            }
            else {
                Console.WriteLine();
                Console.WriteLine("f_selectLogin() >> ERROR - INPUT NOT IN RANGE");
                f_selectLogin();
            }
        }
        public static void f_importCredential() {
            List<string> v_login_list1 = new List<string>();
            List<string> v_login_list2 = new List<string>();
            try {
                using (StreamReader sr1 = new StreamReader("data/id.txt")) {
                    while (sr1.Peek() > -1) {
                        v_login_list1.Add(sr1.ReadLine());
                    }
                }
                using (StreamReader sr2 = new StreamReader("data/pw.txt")) {
                    while (sr2.Peek() > -1) {
                        v_login_list2.Add(sr2.ReadLine());
                    }
                }
                v_login_idlist = v_login_list1.ToArray();
                v_login_pwlist = v_login_list2.ToArray();
            }
            catch(IOException) {
                Console.WriteLine("f_importCredential() >> ERROR - CANNOT READ FILE");
            }
        }
        public static void f_login() {
            string v_login_lv2 = "FAIL";
            f_importCredential();
            Console.Write("ID >> ");
            string v_login_idInput = Console.ReadLine();
            for (int v_login_lv1 = 0; v_login_lv1 < v_login_idlist.Length; v_login_lv1++) {
                if (v_login_idInput == v_login_idlist[v_login_lv1]) {
                    v_login_pwIndex = v_login_lv1;
                    f_login_checkPw();
                    v_login_lv2 = "SUCCESS";
                    v_main_id = v_login_idlist[v_login_lv1];
                    break;
                }
            }
            if (v_login_lv2 != "SUCCESS") {
                Console.WriteLine("f_login() >> ERROR - ID DOES NOT MATCH");
                f_login();
            }
        }
        public static void f_login_checkPw() {
            f_importCredential();
            Console.Write("PW >> ");
            string v_login_pwInput = Console.ReadLine();
            if (v_login_pwInput == v_login_pwlist[v_login_pwIndex]) {
                Console.WriteLine();
                Console.WriteLine("f_login() >> SUCCESSFULLY LOGGED IN");
                // f_loggedIn();
            }
            else {
                Console.WriteLine();
                Console.WriteLine("f_login() >> ERROR - PASSWORD DOES NOT MATCH");
                f_login_checkPw();
            }
        }
        public static void f_register() {
            Console.Write("NEW ID >> ");
            string v_register_idInput = Console.ReadLine();
            Console.Write("NEW PW >> ");
            string v_register_pwInput = Console.ReadLine();
            // add code to confirm password
            try {
                using (StreamWriter sw1 = new StreamWriter("data/id.txt", true)) {
                    sw1.WriteLine(v_register_idInput);
                }
                using (StreamWriter sw2 = new StreamWriter("data/pw.txt", true)) {
                    sw2.WriteLine(v_register_pwInput);
                }
            }
            catch(IOException) {
                Console.WriteLine();
                Console.WriteLine("f_register >> ERROR - CANNOT WRITE TO FILE");
            }
            Console.WriteLine();
            Console.WriteLine("f_register() >> SUCCESSFULLY REGISTERED AS NEW USER");
            Console.WriteLine("f_register() >> LOG IN WITH YOUR NEW CREDENTIAL");
            Console.WriteLine();
            f_login();
        }
        public static void f_selectType() {
            Console.WriteLine();
            Console.WriteLine("f_selectType() >> SELECT INPUT TYPE - CMD/WEB/CLC/CNV/LOG");
            Console.Write("f_selectType() >> ");
            int v_selectType_lv1 = 0;
            string v_selectType_typeInput = Console.ReadLine();
            string v_selectType_isSuccess = "FAIL";
            Console.WriteLine();
            while (v_selectType_lv1 < v_selectType_typeList.Length) {
                Console.WriteLine($"f_debugger() >> f_selectType() PROCESSING - for_{v_selectType_lv1}");
                if (v_selectType_typeInput == v_selectType_typeList[v_selectType_lv1]) {
                    Console.WriteLine($"f_debugger() >> f_selectType() PROCESSING - if_{v_selectType_lv1}");
                    v_selectType_isSuccess = "SUCCESS";
                    if (v_selectType_lv1 == 0) {
                        Console.WriteLine("f_selectType() >> f_typeCmd() SUCCESSFULLY DEPLOYED");
                        f_typeCmd();
                        break;
                    }
                    else if (v_selectType_lv1 == 1) {
                        Console.WriteLine("f_selectType() >> f_typeWeb() SUCCESSFULLY DEPLOYED");
                        f_typeWeb();
                        break;
                    }
                    else if (v_selectType_lv1 == 2) {
                        Console.WriteLine("f_selectType() >> f_typeClc() SUCCESSFULLY DEPLOYED");
                        f_typeClc();
                        break;
                    }
                    else if (v_selectType_lv1 == 3) {
                        Console.WriteLine("f_selectType() >> f_typeCnv() SUCCESSFULLY DEPLOYED");
                        while (true) {
                            f_typeCnv();
                        }
                        // break;
                    }
                    else if (v_selectType_lv1 == 4) {
                        Console.WriteLine("f_selectType() >> f_typeLog() SUCCESSFULLY DEPLOYED");
                        f_typeLog();
                        break;
                    }
                    else {
                        Console.WriteLine("f_selectType() >> ERROR - NO SUCH TYPE DECLARED");
                        break;
                    }
                }
                v_selectType_lv1 += 1;
            }
            if (v_selectType_isSuccess != "SUCCESS") {
                Console.WriteLine("f_selectType() >> NO SUCH TYPE EXISTS");
                f_selectType();
            }
        }
        public static void f_typeCmd() { // priority #2
            Console.WriteLine();
            Console.WriteLine("f_typeCmd() >> CURRENTLY NOT IN ORDER");
        }
        public static void f_typeWeb() { // priority #5
            Console.WriteLine();
            Console.WriteLine("f_typeWeb() >> CURRENTLY NOT IN ORDER");
        }
        public static void f_typeClc() { // pritority #3
            Console.WriteLine();
            Console.WriteLine("f_typeClc() >> CURRENTLY NOT IN ORDER");
        }
        public static void f_typeCnv() { // priority #1
            Console.WriteLine();
            Console.WriteLine("f_typeCnv() >> CURRENTLY IN DEVELOPMENT");
            // get user input & process
            Console.WriteLine("f_typeCnv() >> ENTER A SENTENCE BELOW");
            Console.Write("f_typeCnv() >> ");
            v_typeCnv_userInput = Console.ReadLine();
            v_typeCnv_userInputList = v_typeCnv_userInput.Split();
            Console.WriteLine();
            // f_grammar()
            f_grammar();
            // make comment/reply
            // save to log
        }
        public static void f_grammar() {
            f_grammar_determineType();
            f_grammar_getSubjective();
            // f_grammar_getVerb();
            // f_grammar_determineTense();
            // f_grammar_getObjective();
            // f_grammar_covertToAP(); --> referring to active/passive voice
        }
        public static void f_grammar_determineType() {
            string v_determineType_lastWord = v_typeCnv_userInputList[v_typeCnv_userInputList.Length - 1];
            char v_determineType_lastChar = v_determineType_lastWord[v_determineType_lastWord.Length - 1];
            v_determineType_type = "NONE";
            if (v_determineType_lastChar == '!') {
                v_determineType_type = "EXCLAMATION"; // act as same as "PERIOD"
            }
            else if (v_determineType_lastChar == '?') {
                v_determineType_type = "QUESTION"; // need special function for itself
            }
            else if (v_determineType_lastChar == '.') {
                v_determineType_type = "PERIOD";
            }
            else {
                v_determineType_type = "ERROR";
                Console.WriteLine("f_grammar_determineType() >> ERROR - LAST CHAR ISN'T READABLE");
                f_typeCnv();
            }
            Console.WriteLine("f_debugger() >> f_grammar_determineType() EXECUTED SUCCESSFULLY");
            Console.WriteLine($"f_grammar_determineType() >> SENTENCE TYPE IS '{v_determineType_type}'");
        }
        public static void f_grammar_getSubjective() {
            int v_getSubjective_lv1 = 0;
            int v_getSubjective_lv2 = 0;
            string v_getSubjective_cv1 = "CONTINUE";
            string v_getSubjective_isSuccess = "FAIL";
            while (v_getSubjective_lv1 < v_global_articleList.Length && v_getSubjective_cv1 == "CONTINUE") {
                if (v_typeCnv_userInputList[0] == v_global_articleList[v_getSubjective_lv1]) {
                    // need to determine if the ..[1] is an adjective
                    v_getSubjective_subjective = v_typeCnv_userInputList[1];
                    v_getSubjective_cv1 = "STOP";
                }
                else {
                    v_getSubjective_subjective = v_typeCnv_userInputList[0];
                }
                v_getSubjective_lv1 += 1;
            } 
            while (v_getSubjective_lv2 < v_global_youList.Length && v_getSubjective_isSuccess != "SUCCESS") {
                if (v_getSubjective_lv2 < v_global_meList.Length && v_getSubjective_isSuccess != "SUCCESS") {
                    if (v_getSubjective_subjective == v_global_meList[v_getSubjective_lv2]) {
                        v_getSubjective_subjectiveGeneral = "ME";
                        v_getSubjective_isSuccess = "SUCCESS";
                    }
                }
                if (v_getSubjective_lv2 < v_global_youList.Length && v_getSubjective_isSuccess != "SUCCESS") {
                    if (v_getSubjective_subjective == v_global_youList[v_getSubjective_lv2]) {
                        v_getSubjective_subjectiveGeneral = "YOU";
                        v_getSubjective_isSuccess = "SUCCESS";
                    }
                }
                if (v_getSubjective_lv2 < v_global_heList.Length && v_getSubjective_isSuccess != "SUCCESS") {
                    if (v_getSubjective_subjective == v_global_heList[v_getSubjective_lv2]) {
                        v_getSubjective_subjectiveGeneral = "HE";
                        v_getSubjective_isSuccess = "SUCCESS";
                    }
                }
                if (v_getSubjective_lv2 < v_global_sheList.Length && v_getSubjective_isSuccess != "SUCCESS") {
                    if (v_getSubjective_subjective == v_global_sheList[v_getSubjective_lv2]) {
                        v_getSubjective_subjectiveGeneral = "SHE";
                        v_getSubjective_isSuccess = "SUCCESS";
                    }
                }
                v_getSubjective_lv2 += 1;
            }
            if (v_getSubjective_isSuccess == "FAIL") {
                v_getSubjective_subjectiveGeneral = v_getSubjective_subjective;
                v_getSubjective_isSuccess = "NO_MATCH";
            }
            Console.WriteLine();
            Console.WriteLine("f_debugger() >> f_grammar_getSubjective EXECUTED SUCCESSFULLY");
            if (v_getSubjective_cv1 == "STOP") {
                Console.WriteLine($"f_grammar_getSubjective() >> THIS SENTENCE HAS AN ARTICLE");
            }
            Console.WriteLine($"f_grammar_getSubjective() >> SUBJECTIVE OF THIS SENTENCE IS {v_getSubjective_subjective}");
            Console.WriteLine($"f_grammar_getSubjective() >> GENERAL FORM OF THIS SUBJECTIVE IS {v_getSubjective_subjectiveGeneral}");
        }
        public static void f_typeLog() { // pritority #4
            Console.WriteLine();
            Console.WriteLine("f_typeLog() >> CURRENTLY NOT IN ORDER");
        }
        static void Main(string[] args)
        {
            f_greeting();
            f_selectLogin();
            Console.WriteLine("f_main() >> SUCCESSFULLY LOADED MAIN PAGE");
            Console.WriteLine($"f_main() >> Welcome back, {v_main_id}");
            Console.WriteLine();
            f_selectType();
            // Run main functions from here
        }
    }
}
