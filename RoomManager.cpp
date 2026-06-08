#include "RoomManager.h"
#include <algorithm>
int RoomManager::createRoom(LoggedUser loggedUser, RoomData roomData)
{
	//need to chec if the rome id is exist
	roomData.id = getNextRoomID();
	m_rooms.emplace(roomData.id, Room(roomData));
	m_rooms.at(roomData.id).addUser(loggedUser);
	return roomData.id;
}

void  RoomManager::deleteRoom(int ID)
{
	m_rooms.erase(ID);
}
void RoomManager::startRoom(int ID)
{
	m_rooms.at(ID).setRoomStatus(true);
}


RoomStatus  RoomManager::getRoomState(int ID)
{
	return m_rooms.at(ID).getRoomData().status;
}

std::vector<RoomData> RoomManager::getRooms()
{
	std::vector<RoomData> roomsData;
	for (const auto& room : m_rooms) {
		roomsData.push_back(room.second.getRoomData());
	}
	return roomsData;
}
Room& RoomManager::getRoom(int ID)
{
	return m_rooms.at(ID);
}

int RoomManager::getNextRoomID()
{
	return m_roomID++;
}

bool RoomManager::removeUser(LoggedUser loggedUser)
{
	auto it = std::find_if(m_rooms.begin(), m_rooms.end(), [&](std::pair<const unsigned int, Room>& pair) {// going over all the rooms and find the room whit the user x
		return pair.second.removeUser(loggedUser);// if found remove the user
		});


	if (it != m_rooms.end())
	{
		if ((*it).second.getAllUsers().empty())
		{
			m_rooms.erase(it); // if there not ather user in this room the room is delete
		}
		return true; 
	}

	return false;// if the it connitn end iterator we not find this useron the rooms and return false...

}
