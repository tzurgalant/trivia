#include "LoggedUser.h"


LoggedUser::LoggedUser(std::string userName):m_username(userName)
{

}
LoggedUser::~LoggedUser()
{
	
}
std::string LoggedUser::getUserName() const 
{
	return m_username;
}

bool LoggedUser::operator==(const LoggedUser& other) const {
	return this->m_username == other.m_username;
}