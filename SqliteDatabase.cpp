#include "SqliteDatabase.h"
#include <string>

SqliteDatabase::SqliteDatabase():IDatabase(), _dbFileName("DB.db")
{}

SqliteDatabase::~SqliteDatabase()
{}

bool SqliteDatabase::open() 
{
    //insert user table
    char* errMes = nullptr;
    bool  doesFileExist = _access(_dbFileName.c_str(), 0) == 0;// if the file is exist before
    int res = sqlite3_open(_dbFileName.c_str(), &_db);
    if (!doesFileExist)
    {
        // create all the tables if the file wasnt exist before
        const char* sqlUsers = "CREATE TABLE IF NOT EXISTS USERS ("
            "NAME TEXT PRIMARY KEY NOT NULL,"
            "PASS TEXT NOT NULL,"
            "EMAIL TEXT NOT NULL); ";

        const char* sqlQuestions = "CREATE TABLE IF NOT EXISTS QUESTIONS ("
            "ID INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL,"
            "QUESTION TEXT NOT NULL,"
            "ANSWER1 TEXT NOT NULL,"
            "ANSWER2 TEXT NOT NULL,"
            "ANSWER3 TEXT NOT NULL,"
            "ANSWER4 TEXT NOT NULL,"
            "CORRECT_ANSWER INTEGER NOT NULL);";

        const char* sqlStatistics = "CREATE TABLE IF NOT EXISTS STATISTICS("
            "USERNAME TEXT PRIMARY KEY NOT NULL, "
            "AVG_ANSWER_TIME REAL NOT NULL DEFAULT 0.0, "
            "NUM_CORRECT_ANSWERS INTEGER NOT NULL DEFAULT 0, "
            "NUM_TOTAL_ANSWERS INTEGER NOT NULL DEFAULT 0, "
            "NUM_PLAYED_GAMES INTEGER NOT NULL DEFAULT 0, "
            "FOREIGN KEY(USERNAME) REFERENCES USERS(NAME));";

        const char* sqlCommends[] = {sqlUsers, sqlQuestions, sqlStatistics};

        for (const char* cmd : sqlCommends) {
            res = sqlite3_exec(_db, cmd, nullptr, nullptr, &errMes);

            if (res != SQLITE_OK) {
                std::cout << "Error: " << errMes << std::endl;
                sqlite3_free(errMes);
                break;
            }
        }
    }
    const char* sqlEnableFK = "PRAGMA foreign_keys = ON;";// the gimini say that i need to add this beacuse in the defaluse the sql not enforce foreign key so if i not add this i wiil can delete user whit out delet is alcum first and not give me a error  
    res = sqlite3_exec(_db, sqlEnableFK, nullptr, nullptr, &errMes);
    if (res != SQLITE_OK) {
        std::cout << "SQL Error: " << errMes << std::endl;
        sqlite3_free(errMes);
    }

    return res == SQLITE_OK;
}

bool SqliteDatabase::close() 
{ 
    sqlite3_close(_db);
    _db = nullptr;
    return true;    
}

//user related
bool SqliteDatabase::doesUserExist(std::string name) 
{ 
    sqlite3_stmt* stmt = nullptr;

    std::string sqlCmd = "SELECT PASS FROM USERS WHERE NAME = '" + name + "';";

    if (sqlite3_prepare_v2(_db, sqlCmd.c_str(), -1, &stmt, nullptr) == SQLITE_OK)// if we success to make radey the commend we enter to loop to check each row if ther are a any row is say that we have user!
    {
        while (sqlite3_step(stmt) == SQLITE_ROW)
        {
            const unsigned char* pass = sqlite3_column_text(stmt, 0);
            if (pass)// we found a user whit this id!! so we reutrn true
            {
                sqlite3_finalize(stmt);
                return true;
            }
        }
    }
    sqlite3_finalize(stmt);
    return false;
}

bool SqliteDatabase::doesPasswordMatch(std::string name, std::string pass2)
{
    sqlite3_stmt* stmt = nullptr;
    std::string sqlCmd = "SELECT PASS FROM USERS WHERE NAME = '" + name + "';";

    if (sqlite3_prepare_v2(_db, sqlCmd.c_str(), -1, &stmt, nullptr) == SQLITE_OK)
    {
        if (sqlite3_step(stmt) == SQLITE_ROW)
        {
            const unsigned char* dbPass = sqlite3_column_text(stmt, 0);
            if (dbPass)
            {
                std::string passwordInDb((const char*)dbPass);
                bool match = (passwordInDb == pass2);
                sqlite3_finalize(stmt);
                return match;
            }
        }
    }
    sqlite3_finalize(stmt);
    return false;
}
bool SqliteDatabase::addNewUser(std::string name, std::string pass, std::string email)
{
    char* errMes = nullptr;

    std::string sql = "INSERT INTO USERS (NAME, PASS, EMAIL) VALUES ('" +
        name + "', '" + pass + "', '" + email + "');";

    int res = sqlite3_exec(_db, sql.c_str(), nullptr, nullptr, &errMes);

    if (res != SQLITE_OK)
    {
        if (errMes != nullptr)
        {
            std::cout << "SQL Error in addNewUser: " << errMes << std::endl;
            sqlite3_free(errMes);
        }
        return res;
    }

    return SQLITE_OK;
}

//questions related
std::list<Question> SqliteDatabase::getQuestions(int num)
{
    std::list<Question> questions;
    sqlite3_stmt* stmt = nullptr;

    std::string sqlCmd = "SELECT * FROM QUESTIONS LIMIT ?;";

    if (sqlite3_prepare_v2(_db, sqlCmd.c_str(), -1, &stmt, nullptr) == SQLITE_OK)
    {
        sqlite3_bind_int(stmt, 1, num);

        while (sqlite3_step(stmt) == SQLITE_ROW)
        {
            const unsigned char* rawText = sqlite3_column_text(stmt, 1);
            std::string questionText = (rawText != nullptr) ? reinterpret_cast<const char*>(rawText) : "";

            std::vector<std::string> possibleAnswers;
            possibleAnswers.reserve(4); 
            for (int i = 2; i <= 5; i++)
            {
                rawText = sqlite3_column_text(stmt, i);
                std::string ans = (rawText != nullptr) ? reinterpret_cast<const char*>(rawText) : "";

                possibleAnswers.push_back(std::move(ans));
            }

            int correctAnswer = sqlite3_column_int(stmt, 6);

            questions.emplace_back(questionText, possibleAnswers, correctAnswer);
        }
    }
    else
    {
        std::cout << "Prepare statement for get questions failed: " << sqlite3_errmsg(_db) << std::endl;
    }

    sqlite3_finalize(stmt);

    return questions;
}

//statistics related
float SqliteDatabase::getPlayerAverageAnswerTime(std::string userName)
{
    float averageAnswerTime = 0;

    sqlite3_stmt* stmt = nullptr;
    std::string sqlCmd = "SELECT AVG_ANSWER_TIME FROM STATISTICS WHERE USERNAME = '"  + userName + "';";

    if (sqlite3_prepare_v2(_db, sqlCmd.c_str(), -1, &stmt, nullptr) == SQLITE_OK)
    {
        if (sqlite3_step(stmt) == SQLITE_ROW)
        {
            averageAnswerTime = sqlite3_column_double(stmt, 0);
        }
    }
    else
    {
        std::cout << "prepare stmt for getPlayerAverageAnswerTime failed" << std::endl;
    }
    sqlite3_finalize(stmt);

    return averageAnswerTime;
}

int SqliteDatabase::getNumOfCorrectAnswers(std::string userName)
{
    int correctAnswers = 0;

    sqlite3_stmt* stmt = nullptr;
    std::string sqlCmd = "SELECT NUM_CORRECT_ANSWERS FROM STATISTICS WHERE USERNAME = '" + userName + "';";

    if (sqlite3_prepare_v2(_db, sqlCmd.c_str(), -1, &stmt, nullptr) == SQLITE_OK)
    {
        if (sqlite3_step(stmt) == SQLITE_ROW)
        {
            correctAnswers = sqlite3_column_int(stmt, 0);
        }
    }
    else
    {
        std::cout << "prepare stmt for getNumOfCorrectAnswers failed" << std::endl;
    }
    sqlite3_finalize(stmt);

    return correctAnswers;
}

int SqliteDatabase::getNumOfTotalAnswers(std::string userName)
{
	int totalAnswers = 0;

	sqlite3_stmt* stmt = nullptr;
	std::string sqlCmd = "SELECT NUM_TOTAL_ANSWERS FROM STATISTICS WHERE USERNAME = '" + userName + "';";

	if (sqlite3_prepare_v2(_db, sqlCmd.c_str(), -1, &stmt, nullptr) == SQLITE_OK)
	{
		if (sqlite3_step(stmt) == SQLITE_ROW)
		{
			totalAnswers = sqlite3_column_int(stmt, 0);
		}
	}
	else
	{
		std::cout << "prepare stmt for getNumOfTotalAnswers failed" << std::endl;
	}
	sqlite3_finalize(stmt);

	return totalAnswers;
}

int SqliteDatabase::getNumOfPlayerGames(std::string userName)
{
	int playerGames = 0;

	sqlite3_stmt* stmt = nullptr;
	std::string sqlCmd = "SELECT NUM_PLAYED_GAMES FROM STATISTICS WHERE USERNAME = '" + userName + "';";

	if (sqlite3_prepare_v2(_db, sqlCmd.c_str(), -1, &stmt, nullptr) == SQLITE_OK)
	{
		if (sqlite3_step(stmt) == SQLITE_ROW)
		{
			playerGames = sqlite3_column_int(stmt, 0);
		}
	}
	else
	{
		std::cout << "prepare stmt for getNumOfPlayerGames failed" << std::endl;
	}
	sqlite3_finalize(stmt);

	return playerGames;
}

//scores
int SqliteDatabase::getPlayerScore(std::string userName)
{
	int playerScore = 0;

	sqlite3_stmt* stmt = nullptr;
	std::string sqlCmd = "SELECT NUM_CORRECT_ANSWERS, AVG_ANSWER_TIME FROM STATISTICS WHERE USERNAME = '" + userName + "';";

	if (sqlite3_prepare_v2(_db, sqlCmd.c_str(), -1, &stmt, nullptr) == SQLITE_OK)
	{
		if (sqlite3_step(stmt) == SQLITE_ROW)
		{
			int correctAnswers = sqlite3_column_int(stmt, 0);
			int averageAnswerTime = sqlite3_column_double(stmt, 1);

            playerScore = correctAnswers * (30 - averageAnswerTime); //highscore formula
		}
	}
	else
	{
		std::cout << "prepare stmt for getPlayerScore failed" << std::endl;
	}
	sqlite3_finalize(stmt);

	return playerScore;
}

std::vector<std::string> SqliteDatabase::getHighScores()
{
	std::vector<std::pair<int, std::string>> highScoresPair;

	sqlite3_stmt* stmt = nullptr;
	std::string sqlCmd = "SELECT USERNAME, NUM_CORRECT_ANSWERS, AVG_ANSWER_TIME FROM STATISTICS;";

	if (sqlite3_prepare_v2(_db, sqlCmd.c_str(), -1, &stmt, nullptr) == SQLITE_OK)
	{
		while (sqlite3_step(stmt) == SQLITE_ROW)
		{
			const unsigned char* rawText = sqlite3_column_text(stmt, 0);
			std::string userName = reinterpret_cast<const char*>(rawText);

			int correctAnswers = sqlite3_column_int(stmt, 1);
			int averageAnswerTime = sqlite3_column_double(stmt, 2);

            int playerScore = correctAnswers * (30 - averageAnswerTime); //highscore formula

            highScoresPair.push_back({ playerScore, userName });
		}
	}
	else
	{
		std::cout << "prepare stmt for getHighScores failed" << std::endl;
	}
	sqlite3_finalize(stmt);

	std::sort(highScoresPair.rbegin(), highScoresPair.rend()); //sorting the highscores by the score

    std::vector<std::string> highScores;

    for(auto it = highScoresPair.begin(); it != highScoresPair.end(); it++)
    {
        highScores.push_back(it->second + ", " + std::to_string(it->first));
    }

	return highScores;
}
bool SqliteDatabase::submitGameStatsToDB(std::string playerName, GameData& data)
{
    sqlite3_stmt* stmt;

    const char* sql =
        "INSERT INTO STATISTICS (USERNAME, AVG_ANSWER_TIME, NUM_CORRECT_ANSWERS, NUM_TOTAL_ANSWERS, NUM_PLAYED_GAMES) "
        "VALUES (?, ?, ?, ?, 1) "
        "ON CONFLICT(USERNAME) DO UPDATE SET "
        "   AVG_ANSWER_TIME = ((STATISTICS.AVG_ANSWER_TIME * STATISTICS.NUM_TOTAL_ANSWERS) + ?) / (STATISTICS.NUM_TOTAL_ANSWERS + ?), "
        "   NUM_CORRECT_ANSWERS = STATISTICS.NUM_CORRECT_ANSWERS + ?, "
        "   NUM_TOTAL_ANSWERS = STATISTICS.NUM_TOTAL_ANSWERS + ?, "
        "   NUM_PLAYED_GAMES = STATISTICS.NUM_PLAYED_GAMES + 1;";

    if (sqlite3_prepare_v2(_db, sql, -1, &stmt, nullptr) != SQLITE_OK)
    {
        std::cerr << "Error preparing statement: " << sqlite3_errmsg(_db) << std::endl;
        return false;
    }

    sqlite3_bind_text(stmt, 1, playerName.c_str(), -1, SQLITE_TRANSIENT);
    sqlite3_bind_double(stmt, 2, data.averageAnswerTime);
    sqlite3_bind_int(stmt, 3, data.correctAnswerCount);
    sqlite3_bind_int(stmt, 4, data.correctAnswerCount + data.wrongAnswerCount);

    sqlite3_bind_double(stmt, 5, data.averageAnswerTime);
    sqlite3_bind_int(stmt, 6, data.correctAnswerCount + data.wrongAnswerCount);
    sqlite3_bind_int(stmt, 7, data.correctAnswerCount);
    sqlite3_bind_int(stmt, 8, data.correctAnswerCount + data.wrongAnswerCount);

    int rc = sqlite3_step(stmt);

    sqlite3_finalize(stmt);

    if (rc != SQLITE_DONE)
    {
        std::cerr << "Error executing Upsert: " << sqlite3_errmsg(_db) << std::endl;
        return false;
    }
    return true; 
}