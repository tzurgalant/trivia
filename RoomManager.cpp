#include "RoomManager.h"

void RoomManager::createRoom(LoggedUser loggedUser, RoomData roomData)
{
	//need to chec if the rome id is exist
	roomData.id = getNextRoomID();
	m_rooms.emplace(roomData.id, Room(roomData));
	m_rooms.at(roomData.id).addUser(loggedUser);
}

void  RoomManager::deleteRoom(int ID)
{
	m_rooms.erase(ID);
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

