#pragma once
#include "map"
#include "Room.h"
#include "vector"

class RoomManager
{
public:
	void createRoom(LoggedUser loggedUser, RoomData roomData);
	void deleteRoom(int ID);
	RoomStatus getRoomState(int ID);
	std::vector<RoomData> getRooms();
	Room& getRoom(int ID);
private:
	std::map<unsigned int, Room> m_rooms;
};

