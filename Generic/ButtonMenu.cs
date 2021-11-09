using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CellsAutomat
{
    public class Button
    {
        public readonly string Title;
        public readonly int PositionX;
        public readonly int PositionY;
        public readonly ConsoleColor backgroundColor;
        public readonly ConsoleColor foregroundColor;
        public readonly ConsoleColor selectedBackgroundColor;
        public readonly ConsoleColor selectedForegroundColor;
        public readonly int ID;
        public readonly int Colomn;
        public readonly int Row;
        public Button(string title, int positionX, int positionY, int colomn, int row, ConsoleColor selectedBackgroundColor, ConsoleColor selectedForegroundColor, ConsoleColor backgroundColor, ConsoleColor foregroundColor, int ID)
        {
            this.Title = title;
            PositionX = positionX;
            PositionY = positionY;
            this.selectedBackgroundColor = selectedBackgroundColor;
            this.selectedForegroundColor = selectedForegroundColor;
            this.backgroundColor = backgroundColor;
            this.foregroundColor = foregroundColor;
            this.ID = ID;
            this.Row = row;
            this.Colomn = colomn;
        } 
    }
    public class ButtonMenuAnswer
    {
        public readonly Move Move;
        public readonly int ButtonID;
        public ButtonMenuAnswer(Move move, int buttonID)
        {
            this.Move = move;
            this.ButtonID = buttonID;
        }
    }
    public class ButtonMenu
    {
        private readonly Button[] buttons;
        private Button SelectedButton;
        private readonly string title;
        public ButtonMenuAnswer ChoosedButton
        {
            get
            {
                Console.ResetColor();
                return GetSelectedButton();
            }
        }
        public ButtonMenu(Button[] buttons, string title)
        {
            this.buttons = buttons;
            this.title = title;
            SelectedButton = buttons[0];
            CheckButtonsIDs();
        }
        public ButtonMenu(List<Button> buttons, string title)
        {
            this.buttons = buttons.ToArray();
            this.title = title;
            SelectedButton = buttons[0];
            CheckButtonsIDs();
        }
        private void CheckButtonsIDs()
        {
            foreach (var chekingButton in buttons)
            {
                foreach (var button in buttons)
                {
                    if (chekingButton == button)
                        continue;

                    else if (chekingButton.ID == button.ID)
                        throw new Exception("Совпадение ID кнопok " + chekingButton.Title + " и " + button.Title);

                    else if (chekingButton.Colomn == button.Colomn && chekingButton.Row == button.Row)
                        throw new Exception("Совпадение положения кнопok " + chekingButton.Title + " и " + button.Title);
                }
            }
        }
        private ButtonMenuAnswer GetSelectedButton()
        {
            Console.CursorVisible = false;
            PrintTitle();
            PrintAllButtons();
            PrintSelectedButton();
            ButtonMenuAnswer answer;
            while (true)
            {
                Asic asic;
                var move = MoveReader.GetMoove(SelectedButton.Colomn, SelectedButton.Row, buttons, out asic);
                Console.Beep(1000, 50);
                PrintButton(SelectedButton);
                if (asic == Asic.Y)
                {
                    foreach (var button in buttons)
                        if (button.Row == SelectedButton.Row + (int)move && button.Colomn == SelectedButton.Colomn)
                        {
                            SelectedButton = button;
                            break;
                        }
                }
                else if (asic == Asic.X)
                {
                    foreach (var button in buttons)
                        if (button.Colomn == SelectedButton.Colomn + (int)move && button.Row == SelectedButton.Row)
                        {
                            SelectedButton = button;
                            break;
                        }
                }
                else
                {
                    answer = new(move, SelectedButton.ID);
                    break;
                }
                PrintSelectedButton();
            }
            Console.Beep(1500, 100);
            Console.ResetColor();
            return answer;
        }

        private void PrintTitle()
        {
            Console.SetCursorPosition(0, 0);
            Console.Write(title);
        }

        private void PrintButton(Button button)
        {
            Console.SetCursorPosition(button.PositionX, button.PositionY);
            Console.BackgroundColor = button.backgroundColor;
            Console.ForegroundColor = button.foregroundColor;
            Console.Write(button.Title);
        }
        private void PrintSelectedButton()
        {
            Console.SetCursorPosition(SelectedButton.PositionX, SelectedButton.PositionY);
            Console.BackgroundColor = SelectedButton.selectedBackgroundColor;
            Console.ForegroundColor = SelectedButton.selectedForegroundColor;
            Console.Write(SelectedButton.Title);
        }
        private void PrintAllButtons()
        {
            foreach (var button in buttons)
                PrintButton(button);
        }
    }
}

