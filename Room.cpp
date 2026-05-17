#include "Room.h"

Room::Room(RoomData roomData):m_metadata(roomData)
{

}
void Room::addUser(LoggedUser Luser)
{
	m_users.push_back(Luser);
}
void Room::removeUsers(LoggedUser Luser)
{
	m_users.erase(std::remove(m_users.begin(), m_users.end(), Luser), m_users.end());
}
std::vector<std::string> Room::getAllUsersNames() const
{
	std::vector <std::string> usersNames;
	for (auto user : m_users)
	{
		usersNames.push_back(user.getUserName());
	}
	return usersNames;
}
std::vector<LoggedUser> Room::getAllUsers() const 
{
	return m_users;
}

RoomData Room::getRoomData() const 
{
	return m_metadata;
}