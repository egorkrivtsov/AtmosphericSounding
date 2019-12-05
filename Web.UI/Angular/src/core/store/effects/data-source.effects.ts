import { Injectable } from '@angular/core';
import { Actions, createEffect, ofType } from '@ngrx/effects';
import { of } from 'rxjs';
import { map, mergeMap, catchError } from 'rxjs/operators';
import { DataSourceService } from 'core/services';
import { DataSourceActionTypes } from '../actions/data-source.actions';

@Injectable()
export class DataSourceEffects {

  loadData$ = createEffect(() =>
    this.actions$.pipe(
      ofType(DataSourceActionTypes.Load),
      mergeMap(() => this.dataSourceService.getAll()
        .pipe(
          map(items => ({ type: DataSourceActionTypes.LoadSuccess, payload: items })),
            // TODO: need to think more about  error handling
            // catchError(() => EMPTY)
            // catchError(() => of({ type: '[Movies API] Movies Loaded Error' }))
        )
      )
    )
  );

  constructor(
    private actions$: Actions,
    private dataSourceService: DataSourceService
  ) {}
}
