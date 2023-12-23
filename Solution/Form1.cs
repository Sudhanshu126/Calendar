namespace Calendar
{
    public partial class Form1 : Form
    {
        private static Dictionary<int, string> Months = new Dictionary<int, string>
        {
            {1, "January" },
            {2, "February" },
            {3, "March" },
            {4, "April" },
            {5,  "May"},
            {6, "June" },
            {7, "July" },
            {8, "August" },
            {9, "September" },
            {10, "October" },
            {11, "November" },
            {12, "December" }
        };
        private Label[] Days;

        private int monthMain, yearMain;
        private bool isCurrentMonth;

        public Form1()
        {
            InitializeComponent();

            yearMain = DateTime.Now.Year;
            monthMain = DateTime.Now.Month;

            Days = new Label[]
            {
                day1, day2, day3, day4, day5, day6, day7,
                day8, day9, day10, day11, day12, day13, day14,
                day15, day16, day17, day18, day19, day20, day21,
                day22, day23, day24, day25, day26, day27, day28,
                day29, day30, day31, day32, day33, day34, day35,
                day36, day37, day38, day39, day40, day41, day42
            };
            RefreshCalendar();
        }

        private void RefreshCalendar()
        {
            month.Text = Months[monthMain];
            year.Text = yearMain.ToString();

            int firstDay = FindDay(out int daysInMonth);
            if (monthMain == DateTime.Now.Month && yearMain == DateTime.Now.Year)
            {
                isCurrentMonth = true;
            }
            else
            {
                isCurrentMonth = false;
            }

            PrintCalendar(firstDay, daysInMonth, DateTime.Today.Day + 1);
        }

        private int FindDay(out int daysInMonth)
        {
            daysInMonth = DateTime.DaysInMonth(yearMain, monthMain);
            return (int)new DateTime(yearMain, monthMain, 1).DayOfWeek;
        }

        private void PrintCalendar(int firstDay, int daysInMonth, int today)
        {
            Color todayColor = Color.Crimson, regularColor = Color.DarkSeaGreen;
            int date = 1;
            for (int i = 0; i < Days.Length; i++)
            {
                if (i >= firstDay && date <= daysInMonth)
                {
                    Days[i].Text = date.ToString();
                    date++;
                    Days[i].Visible = true;
                    if (isCurrentMonth && date == today)
                    {
                        Days[i].BackColor = todayColor;
                    }
                    else
                    {
                        Days[i].BackColor = regularColor;
                    }
                }
                else
                {
                    Days[i].Visible = false;
                }
            }
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            monthMain--;
            if (monthMain < 1)
            {
                monthMain = 12;
                yearMain--;
            }
            RefreshCalendar();
        }

        private void forwardButton_Click(object sender, EventArgs e)
        {
            monthMain++;
            if (monthMain > 12)
            {
                monthMain = 1;
                yearMain++;
            }
            RefreshCalendar();
        }
    }
}
