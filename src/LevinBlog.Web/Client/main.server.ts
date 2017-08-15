import 'zone.js/dist/zone-node';
import './polyfills/server.polyfills';
import { enableProdMode } from '@angular/core';
import { INITIAL_CONFIG } from '@angular/platform-server';
import { APP_BASE_HREF } from '@angular/common';
import { createServerRenderer, RenderResult } from 'aspnet-prerendering';

import { ORIGIN_URL } from './app/shared/constants/baseurl.constants';
// Grab the (Node) server-specific NgModule
import { ServerAppModule } from './app/server-app.module';
// Temporary * the engine will be on npm soon (`@universal/ng-aspnetcore-engine`)
import { ngAspnetCoreEngine, IEngineOptions, createTransferScript } from './polyfills/temporary-aspnetcore-engine';

enableProdMode();

export default createServerRenderer((params: BootFuncParams) => {

    // Platform-server provider configuration
    const setupOptions: IEngineOptions = {
        appSelector: '<app></app>',
        ngModule: ServerAppModule,
        request: params,
        providers: [
            // Optional - Any other Server providers you want to pass (remember you'll have to provide them for the Browser as well)
        ]
    };

    return ngAspnetCoreEngine(setupOptions).then(response => {
        // Apply your transferData to response.globals
        response.globals.transferData = createTransferScript({
            AppInsightsId: params.data.appInsightsId,
            DiscusShortName: params.data.discusShortName
        });

        return ({
            html: response.html,
            globals: response.globals
        });
    });
});
