#include "LoginManager.h"

LoginManager::LoginManager(IDatabase* database):m_database(database)
{

}
LoginManager::~LoginManager()
{

}

LoginStatus LoginManager::login(std::string userName, std::string password,SOCKET userSocket)
{
	LoggedUser user = LoggedUser(userName, userSocket);

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
void LoginManager::log_off(SOCKET userSocket)
{
	for (auto it = m_loggedUsers.begin(); it != m_loggedUsers.end(); it++)
	{
		if (it->getUserSocket() == userSocket)
		{
			m_loggedUsers.erase(it);
		}
	}
}

std::string LoginManager::getLoginStatus(LoginStatus status)
{
	switch (status)
	{
		case LOGIN_SUCCESS:  return "LOGIN_SUCCESS";
		case WRONG_PASSWORD: return "WRONG_PASSWORD";
		case WRONG_USERNAME: return "WRONG_USERNAME";
		case ALREADY_LOGGED: return "ALREADY_LOGGED";
		default:             return "";
	}
}

std::string LoginManager::getSignupStatus(SignupStatus status)
{
	switch (status)
	{
	case SIGNUP_SUCCESS:  return "SIGNUP_SUCCESS";
	case USERNAME_TAKEN: return "USERNAME_TAKEN";
	default:             return "";
	}
}