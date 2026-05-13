#pragma once

#include "LoggedUser.h"
#include "IDatabase.h"
#include <WinSock2.h>
#include <iostream>
#include <string>
#include <vector>
#include <map>
#include <socketapi.h>
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

	LoginStatus login(std::string userName, std::string password, SOCKET userSocket);
	SignupStatus sign_up(std::string userName, std::string password, std::string mail);
	void log_off(std::string userName);
	void log_off(SOCKET userSocket);


	// user socket and  user name fucniton
	//std::string getUserName(SOCKET userS);//get user name by his socket
	//void addUserSocketName(SOCKET userS, std::string userN);// add to the map key:userS value:userName
	//void deleteUserSocketName(SOCKET userS);//delete on the map the key:userS

	static std::string getLoginStatus(LoginStatus status);
	static std::string getSignupStatus(SignupStatus status);
	
	bool doesUserLogged(std::string userName);

private:
	IDatabase* m_database;
	std::vector<LoggedUser> m_loggedUsers;
	//std::map <SOCKET, std::string> m_clientsNames;//map that you enter socket and this give you the name of the socket client
};