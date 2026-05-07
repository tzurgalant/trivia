#include "LoginManager.h"

LoginManager::LoginManager(IDatabase* database):m_database(database)
{

}
LoginManager::~LoginManager()
{

}

LoginStatus LoginManager::login(std::string userName, std::string password)
{
	LoggedUser user = LoggedUser(userName);

	if (!m_database->doesUserExist(userName))
	{
		return WRONG_USERNAME;
	}

	if (!m_database->doesPasswordMatch(userName, password))
	{
		return WRONG_PASSWORD;
	}

	if (std::find(m_loggedUsers.begin(), m_loggedUsers.end(), user) != m_loggedUsers.end())
	{
		return ALREADY_LOGGED;
	}

	m_loggedUsers.push_back(user);

	return LOGIN_SUCCESS;
}

SignupStatus LoginManager::sign_up(std::string userName, std::string password, std::string mail)
{
	if (m_database->doesUserExist(userName))
	{
		return USERNAME_TAKEN;
	}

	m_database->addNewUser(userName, password, mail);

	return SIGNUP_SUCCESS;
}

void LoginManager::log_off(std::string userName)
{
	for (auto it = m_loggedUsers.begin(); it != m_loggedUsers.end(); it++)
	{
		if (it->getUserName() == userName)
		{
			m_loggedUsers.erase(it);
		}
	}
}