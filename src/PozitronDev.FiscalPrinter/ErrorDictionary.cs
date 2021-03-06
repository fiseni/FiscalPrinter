﻿using System;
using System.Collections.Generic;
using System.Text;

namespace PozitronDev.FiscalPrinter
{
    public class ErrorDictionary
    {
        public Dictionary<int, string> _dictionary;

        public ErrorDictionary()
        {
            _dictionary = new Dictionary<int, string>()
            {
                //BYTE0
                {0,"Зададените податоци имаат синтаксичка грешка!"},
                {1, "Кодот на примената наредба е невалиден!"},
                {2,"Часовникот не е подесен!"},
                {3, ""},//NOT USE
                {4, "Механизмот за печатење е неисправен"},
                {5, ""},//ОВА ГО КОРИСТАМ АКО САКАМ САМО ФАТАЛНИ ГРЕШКИ ДА ВРАТАМ
                {6, ""},//NOT USE
                {7, ""},//NOT USE
                //BYTE1
                {8, "При извршување на наредбата, сумите предизвикуваат преполнување на некои од полињата!"},
                {9, "Извршувањето на наредбата, сумите предизвикаат преполнување на некои од полињата!"},
                {10, "Извршено ресетирање на RAM меморијата!"},
                {11, "Отворена сторна сметка!"},
                {12, "Има нарушување на содржината на RAM-от по вклучување!"},
                {13, "Капакот на принтерот е отворен!"},
                {14, ""},//NOT USE
                {15, ""},//NOT USE
                //BYTE2
                {16, "Принтерот нема хартија!"},
                {17, "Хартијата е при крај!"},
                {18, "Нема хартија за контролната лента!"},
                {19, "Отворена фискална или сторна сметка!"},
                {20, "Хартијата за контролната лента е при крај!"},
                {21, ""},//NOT USE
                {22, ""},//NOT USE
                {23, ""},//NOT USE
                //BYTE3
                {24, ""},//NOT USE
                {25, ""},//NOT USE
                {26, ""},//NOT USE
                {27, ""},//NOT USE
                {28, ""},//NOT USE
                {29, ""},//NOT USE
                {30, ""},//NOT USE
                {31, ""},//NOT USE
                //BYTE4
                {32, "Има грешка при запис во фискалната меморија!"},
                {33, ""},//NOT USE
                {34, "Нема модул на фискална меморија!"},
                {35, "Останато место за помалку од 40 записи во фискалната меморија!"},
                {36, "Фискалната меморија е полна!"},
                {37, ""},//ОВА ГО КОРИСТАМ АКО САКАМ САМО ФАТАЛНИ ГРЕШКИ ДА ВРАТАМ
                {38, ""},//NOT USE
                {39, ""},//NOT USE
                //BYTE5
                {40, "Фискалната меморија е во режим READONLY!"},
                {41, "Фискалната меморија е форматирана!"},
                {42, ""},//NOT USE
                {43, "Принтерот е фискализиран"},
                {44, "На принтерот е зададена барем една даночна стапка."},
                {45, "Серискиот број на принтерот е програмиран."},
                {46, ""},//NOT USE
                {47, ""},//NOT USE
            };
        }
    }
}
