import { model } from "@angular/core";
import { Cat } from "../../grid-cat/model/cat.model";

export class VoteCat {
    participatingCats: Cat[];
    winnerCatId: string;

    constructor(participatingCats: Cat[], winnerCatId: string)
    {
        this.participatingCats = participatingCats;
        this.winnerCatId = winnerCatId;
    }
}