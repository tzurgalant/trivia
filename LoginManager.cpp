#include "LoginManager.h"

LoginManager::LoginManager()
{

}
LoginManager::~LoginManager()
{

}

LoginStatus LoginManager::login(std::string userName, std::string password)
{
	LoggedUser user = LoggedUser(userName);

	if (std::find(m_loggedUsers.begin(), m_loggedUsers.end(), user) != m_loggedUsers.end())
	{
		return ALREADY_LOGGED;
	}

	if (!m_database->doesUserExist(userName))
	{
		return WRONG_USERNAME;
	}

	if (!m_database->doesPasswordMatch(userName, password))
	{
		return WRONG_PASSWORD;
	}

	m_loggedUsers.push_back(user);

	return LOGIN_SUCCESS;
}
SignupStatus LoginManager::sign_up(std::string userName, std::string password, std::string mail)
{

}

void LoginManager::log_off(std::string userName)
{

}