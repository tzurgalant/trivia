#include "StatisticsManager.h"

std::vector<std::string> StatisticsManager::getHighScore()
{
	std::vector<std::string> highScores = m_database->getHighScores();

	if (highScores.size() > 5)
    {
        highScores.resize(5);
    }

    return highScores;
}

std::vector<std::string> StatisticsManager::getUserStatistics(std::string userName)
{
    std::string avgAnswerTime = std::to_string(m_database->getPlayerAverageAnswerTime(userName));
    std::string correctAnswers = std::to_string(m_database->getNumOfCorrectAnswers(userName));
    std::string totalAnswers = std::to_string(m_database->getNumOfTotalAnswers(userName));
    std::string amountOfGames = std::to_string(m_database->getNumOfPlayerGames(userName));
    std::string userScore = std::to_string(m_database->getPlayerScore(userName));

    std::vector<std::string> userStatistics = {
        avgAnswerTime,
        correctAnswers,
        totalAnswers,
        amountOfGames,
        userScore
    };

    return userStatistics;
}