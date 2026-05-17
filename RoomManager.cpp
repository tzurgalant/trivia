#include "RoomManager.h"

void RoomManager::createRoom(LoggedUser loggedUser, RoomData roomData)
{
	m_rooms[roomData.id] = Room(roomData);
	m_rooms[roomData.id].addUser(loggedUser);
	
}
void  RoomManager::deleteRoom(int ID)
{
	m_rooms.erase(ID);
}
RoomStatus  RoomManager::getRoomState(int ID)
{
	return m_rooms[ID].getRoomData().status;
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
	return m_rooms[ID];
}

