#pragma once
#include "map"
#include "Room.h"
#include "vector"

class RoomManager
{
public:
	RoomManager() = default;
	void createRoom(LoggedUser loggedUser, RoomData roomData);
	void deleteRoom(int ID);
	RoomStatus getRoomState(int ID);
	std::vector<RoomData> getRooms();
	Room& getRoom(int ID);
	int getNextRoomID();
private:
	std::map<unsigned int, Room> m_rooms;
	int m_roomID = 0;
};

