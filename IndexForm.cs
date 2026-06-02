using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using System.Windows.Forms;

namespace WordScrambleApp
{
    public partial class IndexForm : Form
    {
        // =======================================================================
        // ТОВА Е ОБЩИЯТ МЕТОД, КОЙТО СМЕНЯ ЗАГЛАВИЕТО И ВСИЧКИ ТЕКСТОВЕ НАВЕДНЪЖ
        // =======================================================================
        private void UpdateInterfaceLanguage()
        {
            if (currentLanguage == "EN")
            {
                // Смяна на заглавието на самия прозорец на играта
                this.Text = "Word Scramble Game";

                // Смяна на бутоните
                btnCheck.Text = "Check Answer";
                btnNext.Text = "Change Word";
                btnHint.Text = "💡 Get Hint";

                // Смяна на текстовите съобщения и броячи
                lblScore.Text = $"Score: {score}";
                lblErrors.Text = $"Errors: {errors}";
                lblTimerDisplay.Text = $"Time: {timeLeft}s";

                if (!hintUsed)
                    lblHintDisplay.Text = "💡 Click hint to get help!";
            }
            else
            {
                // Смяна на заглавието на самия прозорец на играта
                this.Text = "Игра с разбъркани думи";

                // Смяна на бутоните
                btnCheck.Text = "Провери";
                btnNext.Text = "Смени думата";
                btnHint.Text = "💡 Подсказка";

                // Смяна на текстовите съобщения и броячи
                lblScore.Text = $"Резултат: {score}";
                lblErrors.Text = $"Грешки: {errors}";
                lblTimerDisplay.Text = $"Време: {timeLeft}сек.";

                if (!hintUsed)
                    lblHintDisplay.Text = "💡 Натисни подсказка за помощ!";
            }
        }

        // --- ДАННИ ЗА ИГРАТА ---
        List<string> bgWords = new List<string>();
        List<string> enWords = new List<string>();

        // --- ПРОМЕНЛИВИ ЗА ТЕКУЩОТО СЪСТОЯНИЕ ---
        string currentWord = "";
        string scrambledWord = "";
        int score = 0;
        int errors = 0;
        int timeLeft = 30;
        bool hintUsed = false;
        string currentLanguage = "BG";

        Random random = new Random();

        public IndexForm()
        {
            InitializeComponent();
        }

        // 1. Изпълнява се при стартиране на програмата
        private void IndexForm_Load(object sender, EventArgs e)
        {
            LoadWordsFromFile();

            if (cmbCategory.Items.Count > 0)
            {
                cmbCategory.SelectedIndex = 2;
            }

            currentLanguage = "BG";
            LoadNewWord();
        }

        // 2. Метод за четене на думите от външния файл words.txt
        private void LoadWordsFromFile()
        {
            string filePath = "words.txt";
            bgWords.Clear();
            enWords.Clear();

            try
            {
                if (File.Exists(filePath))
                {
                    string[] lines = File.ReadAllLines(filePath);
                    foreach (string line in lines)
                    {
                        string word = line.Trim();
                        if (word.Length == 5)
                        {
                            if (word.Any(c => (c >= 'а' && c <= 'я') || (c >= 'А' && c <= 'Я')))
                            {
                                bgWords.Add(word);
                            }
                            else
                            {
                                enWords.Add(word);
                            }
                        }
                    }
                }
                else
                {
                    bgWords.AddRange(new[] { "книга", "молив", "чанта", "дъска", "папка" });
                    enWords.AddRange(new[] { "about", "world", "house", "water", "board" });
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading words: " + ex.Message);
            }
        }

        // 3. Метод за избиране и разбъркване на дума
        private void LoadNewWord()
        {
            List<string> selectedList = currentLanguage == "EN" ? enWords : bgWords;

            if (selectedList.Count == 0)
            {
                if (currentLanguage == "EN") enWords.AddRange(new[] { "about", "world", "house" });
                else bgWords.AddRange(new[] { "книга", "молив", "чанта" });
                selectedList = currentLanguage == "EN" ? enWords : bgWords;
            }

            int randomIndex = random.Next(0, selectedList.Count);
            currentWord = selectedList[randomIndex];

            char[] letters = currentWord.ToCharArray();
            for (int i = 0; i < letters.Length; i++)
            {
                int j = random.Next(0, letters.Length);
                char temp = letters[i];
                letters[i] = letters[j];
                letters[j] = temp;
            }
            scrambledWord = new string(letters);

            if (scrambledWord == currentWord && currentWord.Length > 1)
            {
                letters = scrambledWord.ToCharArray();
                Array.Reverse(letters);
                scrambledWord = new string(letters);
            }

            lblScrambledWord.Text = scrambledWord.ToUpper();
            txtGuess.Text = "";
            hintUsed = false;
            btnHint.Enabled = true;
            timeLeft = 30;
            prgTime.Value = 30;

            // Извикваме общия метод най-отгоре, за да преведе всичко (включително заглавието)
            UpdateInterfaceLanguage();

            gameTimer.Start();
        }

        // 4. Бутон "ПРОВЕРИ"
        private void btnCheck_Click(object sender, EventArgs e)
        {
            string playerGuess = txtGuess.Text.Trim().ToLower();

            if (playerGuess == currentWord.ToLower())
            {
                score++;

                if (currentLanguage == "EN")
                    MessageBox.Show("Correct! Well done!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    MessageBox.Show("Точно така! Браво!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);

                LoadNewWord();
            }
            else
            {
                errors++;

                if (currentLanguage == "EN")
                    MessageBox.Show("Wrong guess! Try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                    MessageBox.Show("Грешен отговор! Опитай пак.", "Грешка", MessageBoxButtons.OK, MessageBoxIcon.Error);

                if (!lstWrongWords.Items.Contains(currentWord))
                {
                    lstWrongWords.Items.Add(currentWord);
                }

                // Обновяваме брояча за грешки през общия метод
                UpdateInterfaceLanguage();
            }
        }

        // 5. Бутон "СМЕНИ ДУМАТА" / "ПРОПУСНИ"
        private void btnNext_Click(object sender, EventArgs e)
        {
            if (!lstWrongWords.Items.Contains(currentWord))
            {
                lstWrongWords.Items.Add(currentWord);
            }
            LoadNewWord();
        }

        // 6. Бутон за ПОДСКАЗКА
        private void btnHint_Click(object sender, EventArgs e)
        {
            if (!hintUsed && currentWord.Length > 2)
            {
                char firstLetter = currentWord[0];
                char lastLetter = currentWord[currentWord.Length - 1];

                if (currentLanguage == "EN")
                    lblHintDisplay.Text = $"💡 Hint: Starts with '{firstLetter}' and ends with '{lastLetter}'";
                else
                    lblHintDisplay.Text = $"💡 Подсказка: Започва с '{firstLetter}' and завършва на '{lastLetter}'";

                hintUsed = true;
                btnHint.Enabled = false;
            }
        }

        // 7. Смяна на езика на Български
        private void btnLangBG_Click(object sender, EventArgs e)
        {
            currentLanguage = "BG";
            btnLangBG.Text = "BG 🇧🇬 (Active)";
            btnLangEN.Text = "EN 🇺🇸";

            LoadNewWord();
        }

        // 8. Смяна на езика на Английски
        private void btnLangEN_Click(object sender, EventArgs e)
        {
            currentLanguage = "EN";
            btnLangBG.Text = "BG 🇧🇬";
            btnLangEN.Text = "EN 🇺🇸 (Active)";

            LoadNewWord();
        }

        // 9. Логика на Таймера
        private void gameTimer_Tick(object sender, EventArgs e)
        {
            if (timeLeft > 0)
            {
                timeLeft--;
                prgTime.Value = timeLeft;

                if (currentLanguage == "EN")
                    lblTimerDisplay.Text = $"Time: {timeLeft}s";
                else
                    lblTimerDisplay.Text = $"Време: {timeLeft}сек.";
            }
            else
            {
                gameTimer.Stop();
                if (!lstWrongWords.Items.Contains(currentWord))
                {
                    lstWrongWords.Items.Add(currentWord);
                }

                if (currentLanguage == "EN")
                    MessageBox.Show($"Time's up! The word was: {currentWord}", "Timeout", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                else
                    MessageBox.Show($"Времето изтече! Думата беше: {currentWord}", "Времето изтече", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                LoadNewWord();
            }
        }

        private void cmbCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.Created)
            {
                LoadNewWord();
            }
        }

        private void txtNewWord_TextChanged(object sender, EventArgs e)
        {
            // Оставя се празен
        }
    }
}