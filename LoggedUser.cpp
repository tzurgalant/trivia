#include "LoggedUser.h"


LoggedUser::LoggedUser(std::string userName, SOCKET userSocket):m_username(userName),m_usersocket(userSocket)
{

}
LoggedUser::~LoggedUser()
{
	
}
std::string LoggedUser::getUserName() const 
{
	return m_username;
}
SOCKET LoggedUser::getUserSocket() const
{
	return m_usersocket;
}
bool LoggedUser::operator==(const LoggedUser& other) const {
	return this->m_username == other.m_username;
}
bool LoggedUser::operator<(const LoggedUser& other) const
{
	return this->m_username < other.m_username;
}
