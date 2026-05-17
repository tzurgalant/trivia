#pragma once
#include <iostream>
#include "LoggedUser.h"
#include <vector>

typedef bool RoomStatus;


struct RoomData
{
	unsigned int id;
	std::string name;	
	unsigned int maxPlayers;
	unsigned int numOfQuestionsInGame;
	unsigned int timePerQuestion;
	RoomStatus status;
};


class Room
{
private:
	RoomData m_metadata;
	std::vector<LoggedUser>m_users;
public:
	Room();
	void addUser(LoggedUser Luser);
	void removeUsers(LoggedUser Luser);
	std::vector<std::string> getAllUsers();
};

