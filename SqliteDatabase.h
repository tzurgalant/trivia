#pragma once
#include "IDatabase.h"
#include "Question.h"
#include <io.h>   
#include "sqlite3.h"
#include <list>

class SqliteDatabase :public IDatabase
{
public:
	SqliteDatabase();
	~SqliteDatabase();

	bool open() override;
	bool close() override;

	//users related
	int doesUserExist(std::string name) override;
	int doesPasswordMatch(std::string name, std::string pass2)  override;
	int addNewUser(std::string name, std::string pass, std::string email) override;

	//questions related
	std::list<Question> getQuestions() override;

private:
	sqlite3* _db = nullptr;
	std::string _dbFileName;
};

