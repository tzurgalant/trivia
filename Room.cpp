#include "Room.h"

Room::Room(RoomData roomData):m_metadata(roomData)
{

}
bool Room::addUser(LoggedUser Luser)
{
	if (m_users.size() != m_metadata.maxPlayers)
	{
		m_users.push_back(Luser);
		return true;
	}
	return false;
}
bool Room::removeUser(LoggedUser Luser)
{
	size_t originalSize = m_users.size();

	m_users.erase(std::remove(m_users.begin(), m_users.end(), Luser), m_users.end());

	return m_users.size() < originalSize;/// if was a this user on the vector return true 
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
void Room::setRoomStatus(RoomStatus status)
{
	m_metadata.status = status;
}