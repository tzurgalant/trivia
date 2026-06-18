#pragma once

#include "IDatabase.h"
#include "LoginManager.h"
#include "RoomManager.h"
#include "StatisticsManager.h"
#include "GameManager.h"
// because i have loop of calling of librarys we need to do Forward Declarations 
class RoomMemberRequestHandler;
class RoomAdminRequestHandler;
class LoginRequestHandler;
class MenuRequestHandler;
class IRequestHandler;
class GameRequestHandler;

class RequestHandlerFactory
{
public:
	RequestHandlerFactory(IDatabase* database);
	~RequestHandlerFactory();

	LoginRequestHandler* createLoginRequestHandler();
	MenuRequestHandler* createMenuRequestHanlder(LoggedUser Luser);
	RoomMemberRequestHandler* createRoomMemberRequestHandler(RoomManager roomManager, LoggedUser Luser, Room& room);
	RoomAdminRequestHandler* createRoomAdminRequestHandler(Room& room,LoggedUser user, RoomManager& roomManager);
	GameRequestHandler* createGameRequestHandler(Game& game, LoggedUser user, GameManager& gm);
	void changeRequestHandler(RequestResult* res, IRequestHandler*& reqHandler);


	LoginManager& getLoginManager();
	RoomManager& getRoomManager();
	StatisticsManager& getStatisticsManager();
	GameManager& getGameManager();
private:
	LoginManager m_loginManager;
	RoomManager m_roomManager;
	StatisticsManager m_statisticsManager;
	GameManager m_gameManager;
};