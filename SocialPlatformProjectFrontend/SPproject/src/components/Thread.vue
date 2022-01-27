<template>
  <div class="container">
      <div class="category">
          <div v-for="category in GetCategory" :key="category.Id" class="category-title">
              <h2>{{category.Title}}</h2>
          </div>
      </div>
       <div v-for="threads in GetThreads" :key="threads.Id" class="subforum-description">
          <div class="subforum-row">
            <div class="subforum-icon subforum-column center" > 
                    <i class="fas fa-laptop"></i>
                </div>
            <div class="subforum-description subforum-column" >
            <h1>{{ threads.Title }} <small>Posted by <a href="">User</a> 15 Jan 2022</small></h1>
            <p> {{ threads.Text }} </p>
            <a class="post-link" href=""><router-link to="/Post">Reply</router-link></a>
            <a class="post-link" href=""><router-link to="/">Save</router-link></a>
          </div>
          
         </div>


       </div>
  </div>
  <!-- <div class="container" >
    <div class="subform">
            <div class="subforum-title">
                <h1>General Information</h1>
            </div>
          </div>
          <div class="subforum-row">
                <div class="subforum-icon subforum-column center" > 
                    <i class="fas fa-laptop"></i>
                </div>
                <div class="subforum-description subforum-column">
                    <h1>Descriptiption Title <small>Posted by <a href="">User</a> 15 Jan 2022</small></h1>
                    <p>Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Lectus sit amet est placerat. Lacus viverra vitae congue eu consequat ac felis donec et. 
                      Tempus quam pellentesque nec nam aliquam sem et tortor. Mi proin sed libero enim. Purus non enim praesent elementum facilisis. Amet nisl purus in mollis nunc sed.</p>
                    <a class="post-link" href=""><router-link to="/Post">Reply</router-link></a>
                    <a class="post-link" href=""><router-link to="/">Save</router-link></a>
                </div>
          </div>
  </div> -->
</template>

<script>

export default{

  data(){
    return{
      cId: this.$route.params.Id,
      catId: this.$route.params.Id
    }
  },

  computed:{
    GetThreads(){
        
      let list = this.$store.state.Thread;
      //let list2 = {...this.$store.state.Thread};
      //let result = [];
      // console.log('urlCategoryId ' + this.cId)
      // console.log('Under här är listan')
      // console.log(list)
      
      let filterlist = list.filter(
        
        (item) =>{
          return item.CategoryId == this.cId;
        }
      );
      console.log(filterlist);
      return filterlist;
      
    },
    GetCategory(){

      let categoryList = this.$store.state.Category

      let filterList = categoryList.filter(
        (item) => {
          
          return item.Id == this.catId;
        }
      );
      console.log("this is categorylist")
      console.log(filterList)
      return filterList;

      // return this.$store.state.Category
    },
  }
}

</script>


<style scoped>

   *{
     box-sizing: border-box;
   }

  a{
    color: rgb(153, 149, 163);
    font-weight: bolder;
  }

  p{
    color:white;
  }

  .post-link > a{
    color: white;
    padding-right: 10px;
    font-size: 12px;
  }

  h1{
    font-size: 18px;
    font-weight: bolder;
    color: white;
  }

  /*Body*/
  .container{
    width: 500vh;
    padding:20px;
    background: rgb(173, 173, 173);
    border-radius: 5px;
    margin-bottom: 20px;
  }


  .subforum{
    margin-top: 20px;
  }

  .subforum-title{
    background-color:rgb(119, 119, 119);
    padding: 10px;
    border-radius: 5px;
    margin: 4px;
  }

  .subforum-row{
    display: grid;
    grid-template-columns: 7% 93% ;
  }

  .subforum-column{
    border-radius: 5px;
    margin: 4px;
    background-color: rgb(48, 48, 48);
  }

  .subforum-description{
    padding:10px;
  }

  .center{
    display:flex;
    justify-content: center;
    align-items: center;
  }

  .subforum-icon{
    font-size:30px;
  }

  /*Category*/
   .category{
   margin-top: 20px;
  }

.category-title{
    background-color:rgb(119, 119, 119);
    padding: 10px;
    border-radius: 5px;
    margin: 4px;
    margin-bottom:20px;
}
</style>
