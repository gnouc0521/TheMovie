import {Store,Module,ActionContext} from 'vuex'
import ListModule from './list-module'
import ListState from './list-state'
import TypeFilm from '../entities/typefilm'
import Ajax from '../../lib/ajax'
import PageResult from '@/store/entities/page-result';

interface TypeFilmState extends ListState<TypeFilm>{
    editMovie:TypeFilm;
}
class MovieModule extends ListModule<TypeFilmState,any,TypeFilm>{
    state={
        totalCount:0,
        currentPage:1,
        pageSize:10,
        list: new Array<TypeFilm>(),
        loading:false,
        editMovie:new TypeFilm(),
    }
    actions={
        async getAll(context:ActionContext<TypeFilmState,any>,payload:any){
            context.state.loading=true;
            let reponse=await Ajax.get('/api/services/app/TypeFilm/GetAll',{params:payload.data});
            context.state.loading=false;
            let page=reponse.data.result as PageResult<TypeFilm>;
            context.state.totalCount=page.totalCount;
            context.state.list=page.items;
        },
        async create(context:ActionContext<TypeFilmState,any>,payload:any){
            await Ajax.post('/api/services/app/TypeFilm/Create',payload.data);
        },
        async update(context:ActionContext<TypeFilmState,any>,payload:any){
            await Ajax.put('/api/services/app/TypeFilm/Update',payload.data);
        },
        async delete(context:ActionContext<TypeFilmState,any>,payload:any){
            await Ajax.delete('/api/services/app/TypeFilm/Delete?Id='+payload.data.id);
        },
        async get(context:ActionContext<TypeFilmState,any>,payload:any){
            let reponse=await Ajax.get('/api/services/app/TypeFilm/GetbyId?Id='+payload.id);
            return reponse.data.result as TypeFilm;
        },
    };
    mutations={
        setCurrentPage(state:TypeFilmState,page:number){
            state.currentPage=page;
        },
        setPageSize(state:TypeFilmState,pagesize:number){
            state.pageSize=pagesize;
        },
        edit(state:TypeFilmState,movie:TypeFilm){
            state.editMovie=movie;
        }
    }
}
const typefilmModule=new MovieModule();
export default typefilmModule;