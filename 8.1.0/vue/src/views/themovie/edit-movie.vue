<template>
    <div>
        <Modal
         :title="L('EditMovie')"
         :value="value"
         @on-ok="save"
         @on-visible-change="visibleChange"
        >
            <Form ref="movieForm"  label-position="top" :model="movie">
                <Tabs value="detail">
                    <TabPane :label="('MovieDetails')" name="detail">
                        <FormItem :label="('Title')" prop="title">
                            <Input v-model="movie.title" :maxlength="32" :minlength="2"></Input>
                        </FormItem>
                        <FormItem :label="('Description')" prop="description">
                            <Input v-model="movie.description" :maxlength="32" :minlength="2"></Input>
                        </FormItem>
                        <FormItem :label="('pathMovie')" prop="pathMovie">
                            <Input v-model="movie.pathMovie" :maxlength="1024"></Input>
                        </FormItem>
                        <FormItem :label="('URL')" prop="url">
                            <Input v-model="movie.url" :maxlength="1024"></Input>
                        </FormItem>
                      </TabPane>
                </Tabs>
            </Form>
            <div slot="footer">
                <Button @click="cancel">{{('Cancel')}}</Button>
                <Button @click="save" type="primary">{{('OK')}}</Button>
            </div>
        </Modal>
    </div>
</template>
<script lang="ts">
    import { Component, Vue,Inject, Prop,Watch } from 'vue-property-decorator';
    import Util from '../../lib/util'
    import AbpBase from '../../lib/abpbase'
    import Role from '@/store/entities/role';
    import Movie from '@/store/entities/movie';
    @Component
    export default class EditMovie extends AbpBase{
        @Prop({type:Boolean,default:false}) value:boolean;
        role:Role=new Role();
        movie:Movie=new Movie();
        get permissions(){
            return this.$store.state.role.permissions
        }
        save(){
            (this.$refs.movieForm as any).validate(async (valid:boolean)=>{
                if(valid){
                    await this.$store.dispatch({
                        type:'movie/update',
                        data:this.movie
                    });
                    (this.$refs.movieForm as any).resetFields();
                    this.$emit('save-success');
                    this.$emit('input',false);
                }
            })
        }
        cancel(){
            (this.$refs.movieForm as any).resetFields();
            this.$emit('input',false);
        }
        visibleChange(value:boolean){
            if(!value){
                this.$emit('input',value);
            }else{
                this.movie=Util.extend(true,{},this.$store.state.movie.editMovie);
            }
        }
    }
</script>

