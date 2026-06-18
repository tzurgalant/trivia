#include "LoginRequestHandler.h"
#include "MenuRequestHandler.h"
#include "RoomMemberRequestHandler.h"
#include "RoomAdminRequestHandler.h"
#include "GameRequestHandler.h"

RequestHandlerFactory::RequestHandlerFactory(IDatabase* database) : m_loginManager(database),m_statisticsManager(database),m_gameManager(database)
{

}
RequestHandlerFactory::~RequestHandlerFactory()
{

}

void RequestHandlerFactory::changeRequestHandler(RequestResult* res, IRequestHandler*& reqHandler)
{
    if (res->newHandler != nullptr)
    {
        if (reqHandler != nullptr)
        {
            delete reqHandler;
        }

        reqHandler = res->newHandler;
    }
}


MenuRequestHandler* RequestHandlerFactory::createMenuRequestHanlder(LoggedUser Luser)
{
	return new  MenuRequestHandler(*this,Luser);
}


LoginRequestHandler* RequestHandlerFactory::createLoginRequestHandler()
{
	return new LoginRequestHandler(*this);
}

RoomMemberRequestHandler* RequestHandlerFactory::createRoomMemberRequestHandler(RoomManager roomManager, LoggedUser Luser, Room& room)
{
    return new RoomMemberRequestHandler(*this, roomManager, Luser, room);
}
RoomAdminRequestHandler* RequestHandlerFactory::createRoomAdminRequestHandler(Room& room, LoggedUser Luser, RoomManager& roomManager)
{
    return new RoomAdminRequestHandler(room, Luser,roomManager, *this);
}
GameRequestHandler* RequestHandlerFactory::createGameRequestHandler(Game& game, LoggedUser user, GameManager& gameManager)
{
    return new GameRequestHandler(game, user, gameManager, *this);
}
LoginManager& RequestHandlerFactory::getLoginManager() 
{
	return m_loginManager;
}

RoomManager& RequestHandlerFactory::getRoomManager()
{
    return m_roomManager;
}

StatisticsManager& RequestHandlerFactory::getStatisticsManager()
{
    return m_statisticsManager;
}
GameManager& RequestHandlerFactory::getGameManager()
{
    return m_gameManager;
}

