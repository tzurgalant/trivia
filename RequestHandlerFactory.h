#pragma once

#include "IDatabase.h"
#include "LoginManager.h"
#include "RoomManager.h"
#include "StatisticsManager.h"
// because i have loop of calling of librarys we need to do Forward Declarations 
class LoginRequestHandler;
class MenuRequestHandler;
class IRequestHandler;

class RequestHandlerFactory
{
public:
	RequestHandlerFactory(IDatabase* database);
	~RequestHandlerFactory();

	LoginRequestHandler* createLoginRequestHandler();
	MenuRequestHandler* createMenuRequestHanlder(LoggedUser Luser);
	void changeRequestHandler(RequestResult* res, IRequestHandler*& reqHandler);


	LoginManager& getLoginManager();
	RoomManager& getRoomManager();
	StatisticsManager& getStatisticsManager();
private:
	LoginManager m_loginManager;
	RoomManager m_roomManager;
	StatisticsManager m_statisticsManager;
};