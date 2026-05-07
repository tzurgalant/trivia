#include "LoginManager.h"

LoginManager::LoginManager()
{

}
LoginManager::~LoginManager()
{

}

void LoginManager::login(std::string userName, std::string password)
{
	if (m_database->doesUserExist(userName) && m_database->doesPasswordMatch(userName, password))
	{

	}
}
void LoginManager::sign_up(std::string userName, std::string password, std::string mail)
{

}

void LoginManager::log_off(std::string userName)
{

}