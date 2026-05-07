#pragma once

#include "LoggedUser.h"
#include "IDatabase.h"

#include <iostream>
#include <string>
#include <vector>

enum LoginStatus {
	LOGIN_SUCCESS,
	WRONG_USERNAME,
	WRONG_PASSWORD,
	ALREADY_LOGGED
};

enum SignupStatus {
	SIGNUP_SUCCESS,
	USERNAME_TAKEN
};

class LoginManager
{
public:
	LoginManager(IDatabase* database);
	~LoginManager();

	LoginStatus login(std::string userName, std::string password);
	SignupStatus sign_up(std::string userName, std::string password, std::string mail);
	void log_off(std::string userName);

private:
	IDatabase* m_database;
	std::vector<LoggedUser> m_loggedUsers;
};

