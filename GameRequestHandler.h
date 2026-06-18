#pragma once
#include "IRequestHandler.h" 
#include "Game.h"
#include "LoggedUser.h"
#include "GameManager.h"
#include "RequestHandlerFactory.h"





class GameRequestHandler : public IRequestHandler {

public:
    GameRequestHandler(Game& game, LoggedUser user, GameManager& gm, RequestHandlerFactory& rhf);

    bool isRequestRelevant(const RequestInfo& info) override;
    RequestResult handleRequest(const RequestInfo& info) override;
private:
    Game& m_game;
    LoggedUser m_user;
    GameManager& m_gameManager;
    RequestHandlerFactory& m_handlerFactory;

    RequestResult getQuestion(const RequestInfo& info);
    RequestResult submitAnswer(const RequestInfo& info);
    RequestResult getGameResults(const RequestInfo& info);
    RequestResult leaveGame(const RequestInfo& info);

};