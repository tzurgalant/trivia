#pragma once

#include "LoggedUser.h"
#include "IDatabase.h"

#include <iostream>
#include <string>
#include <vector>

class LoginManager
{
public:
	LoginManager();
	~LoginManager();

	void login(std::string userName, std::string password);
	void sign_up(std::string userName, std::string password, std::string mail);
	void log_off(std::string userName);

private:
	IDatabase* m_database;
	std::vector<LoggedUser> _logged_users;
};