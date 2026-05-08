#pragma once

#include <string>
#include <WinSock2.h>
class LoggedUser
{
public:
	LoggedUser(std::string userName,SOCKET userSocket);
	~LoggedUser();
	std::string getUserName() const ;
	SOCKET getUserSocket() const;
	bool operator==(const LoggedUser& other) const;
private:
	std::string m_username;
	SOCKET m_usersocket;
};