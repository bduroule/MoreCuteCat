import { model } from "@angular/core";

export class Cat {
    id : string// model.required<string>();
    url = model.required<string>();
    score = model.required<number>();
}