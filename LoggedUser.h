#pragma once

#include <string>

class LoggedUser
{
public:
	LoggedUser(std::string userName);
	~LoggedUser();
	std::string getUserName() const ;
	bool operator==(const LoggedUser& other) const;
private:
	std::string m_username;
};