import { Routes } from '@angular/router';
import { GridCatComponent } from './componants/grid-cat/grid-cat.component';
import { CatChooserComponent } from './componants/cat-chooser/CatChooserComponent';

export const routes: Routes = [
    { path: 'gridCat', component: GridCatComponent},
    { path: 'catChoice', component: CatChooserComponent},
    {path: '', redirectTo: 'catChoice', pathMatch: 'full'}
];
