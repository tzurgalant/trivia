#pragma once
#include "IDatabase.h"
#include <io.h>   
#include "sqlite3.h"

class SqliteDatabase :IDatabase
{
public:
	SqliteDatabase();
	~SqliteDatabase();

	bool open() override;
	bool close() override;
	int doesUserExist(std::string name) override;
	int doesPasswordMatch(std::string name, std::string pass2)  override;
	int addNewUser(std::string name, std::string pass, std::string email) override;
private:
	sqlite3* _db = nullptr;
	std::string _dbFileName;
};

