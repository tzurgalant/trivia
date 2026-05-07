#pragma once

#include <string>

class LoggedUser
{
public:
	LoggedUser(std::string userName);
	~LoggedUser();
	std::string getUserName();

private:
	std::string m_username;
};