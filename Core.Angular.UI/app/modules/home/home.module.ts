import { NgModule } from "@angular/core";
import { CommonModule } from "@angular/common";
import { RouterModule } from "@angular/router";
import { HomeComponent } from "./components/home/home.component";
import { HomeRouterComponent } from "./home-router.component";
import { HomeRouterModule } from "./home-router.module";
import { AppCommonModule } from "../common/common.module";
import { UserService } from "../account/services/user.service";
import { AdventuresComponent } from "./components/home/adventures/adventures.component";
import { ExperiencesComponent } from "./components/home/experiences/experiences.component";
import { AdventureService } from "./services/adventure.service";
import { AdventureComponent } from "./components/home/adventures/adventure/adventure.component";
import { NgbDatepickerModule } from "@ng-bootstrap/ng-bootstrap";
import { FormsModule } from '@angular/forms';
import { AdventureHubService } from "./services/adventure-hub.service";
import { ChatHubService } from "./services/chat-hub.service";

@NgModule({
	imports: [
		CommonModule,
		AppCommonModule,
		RouterModule,
		HomeRouterModule,
		NgbDatepickerModule,
		FormsModule
	],
	declarations: [
		HomeRouterComponent,
		HomeComponent,
		AdventuresComponent,
		AdventureComponent,
		ExperiencesComponent,
	],
	providers: [
		UserService,
		AdventureService,
		AdventureHubService,
		ChatHubService
	]
})
export class HomeModule {}
