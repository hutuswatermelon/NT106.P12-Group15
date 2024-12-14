using System.Text;
using System.Timers;

namespace frmServer
{
    internal class Room
    {
        private int roomNumber;
        private int storyTimeLimit = 15; // Thời gian cho mỗi câu chuyện
        private Dictionary<User, List<string>> userStories; // Lưu trữ danh sách câu chuyện của mỗi user
        private int currentRound = 0; // Vòng hiện tại
        private int maxRounds = 2; // Số lượt tối đa cho trò chơi
        private Dictionary<User, string> currentSentences; // Tạm lưu các câu trong vòng hiện tại
        private bool isGameStarted = false;
        private bool isRoundSubmitted = false;
        private int maxPlayers = 2;
        public bool IsRoundSubmitted
        {
            get { return isRoundSubmitted; }
            set { isRoundSubmitted = value; }
        }

        List<User> listPlayer = new List<User>();

        public List<User> ListPlayer
        {
            get { return listPlayer; }
            set { listPlayer = value; }
        }
        
        public int MaxPlayers
        {
            get { return maxPlayers; }
            set { maxPlayers = value; }
        }
        public int RoomNumber
        {
            get { return roomNumber;}
            set { roomNumber = value; }
        }
        public int MaxRounds // Thêm thuộc tính MaxRounds với get và set
        {
            get { return maxRounds; }
            set { maxRounds = value; }
        }

        public int CurrentRound
        {
            get { return currentRound; }
            set { currentRound = value; }
        }
        public int StoryTimeLimit
        {
            get { return storyTimeLimit; }
            set { storyTimeLimit = value; }
        }
        public Room(int id)
        {
            roomNumber = id;
            storyTimeLimit = 15;
            userStories = new Dictionary<User, List<string>>();
            maxRounds = 2;
            currentRound = 0;
            currentSentences = new Dictionary<User, string>();
        }
        public bool addPlayer(User us)
        {
            if (listPlayer.Count <= maxPlayers) // Kiểm tra dựa trên maxPlayers
            {
                listPlayer.Add(us);
                userStories[us] = new List<string>();
                return true;
            }
            return false;
        }
        public int playerCount()
        {
            return listPlayer.Count();
        }
        public void StartGame()
        {
            if (!isGameStarted && listPlayer.Count >= 2)
            {
                currentRound = 0;
                isGameStarted = true;
                StartNextRound();
            }
        }
        public void StartNextRound()
        {
            if (currentRound >= maxRounds)
            {
                EndGame();
                return;
            }
            isRoundSubmitted = false;
            foreach (var user in listPlayer)
            {
                user.HasSubmitted = false; // Đánh dấu người chơi chưa nộp
            }
            currentRound++;
        }


        // Lưu câu hiện tại cho user
        public void SubmitSentence(User user, string sentence)
        {
            lock (lockObject)
            {
                if (!userStories.ContainsKey(user))
                {
                    userStories[user] = new List<string>();
                }
                if (!currentSentences.ContainsKey(user))
                {
                    if (currentRound <= 1)
                    {
                        currentSentences[user] = sentence;

                        userStories[user].Add(sentence);
                    }
                    else
                    {
                        currentSentences[user] = sentence;
                    }

                    user.HasSubmitted = true;
                }
                user.HasSubmitted = true;
                // Kiểm tra xem tất cả người chơi đã nộp câu chưa
                isRoundSubmitted = listPlayer.All(u => u.HasSubmitted);
            }
        }

        private readonly object lockObject = new object();


        public List<string> showRotateStories()
        {
            lock (lockObject)
            {
                List<string> rotatedSentences = new List<string>();

                // For each player, assign the rotated sentence they receive from another player
                for (int i = 0; i < ListPlayer.Count; i++)
                {
                    User currentUser = ListPlayer[i];
                    User nextUser = ListPlayer[(i + 1) % ListPlayer.Count]; // Simple rotation logic

                    if (currentSentences.ContainsKey(nextUser))
                    {
                        // Retrieve the sentence from the next player in rotation
                        string rotatedSentence = currentSentences[nextUser];

                        userStories[currentUser].Add(rotatedSentence);

                        rotatedSentences.Add(rotatedSentence);
                    }
                }

                if (currentRound < MaxRounds)
                {
                    currentSentences.Clear();
                }

                return rotatedSentences;
            }
        }



        public void EndGame()
        {
            isGameStarted = false;
        }

        public string GetCompleteStories()
        {
            List<string> completeStoryList = new List<string>();

            // Lặp qua các câu chuyện của từng người chơi
            foreach (var user in userStories.Keys)
            {
                List<string> receivedStorySequence = userStories[user];

                // Ghép các câu lại thành một câu chuyện hoàn chỉnh
                string completeStory = string.Join(" ", receivedStorySequence);

                // Định dạng: Tên người chơi: Câu chuyện hoàn chỉnh
                completeStoryList.Add($"{user.UserName}: {completeStory}");
            }

            // Trả về các câu chuyện hoàn chỉnh của tất cả người chơi
            return string.Join("|", completeStoryList);
        }
        public void ResetRoom()
        {
            lock (lockObject)
            {
                // Reset tất cả các thuộc tính của phòng
                currentRound = 0;
                isGameStarted = false;
                isRoundSubmitted = false;
                storyTimeLimit = 15;
                maxRounds = 2;
                maxPlayers = 2;


                // Xóa các danh sách và dictionary
                currentSentences.Clear();
                userStories.Clear();

                // Đặt lại trạng thái của tất cả người chơi trong phòng
                foreach (var user in listPlayer)
                {
                    user.HasSubmitted = false;
                }
            }
        }

    }
}
