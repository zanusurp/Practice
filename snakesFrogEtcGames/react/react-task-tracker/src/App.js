
import {useState, useEffect} from 'react'
import {BrowserRouter as Router, Route} from 'react-router-dom'
import Header from './components/Header'
import Tasks from './components/Tasks'
import AddTask from './components/AddTask'
import Footer from './components/Footer'
import About from './components/about'


function App() {
  const [showAddTask, setShowAddTask] = useState(false);
  const [tasks,setTasks] = useState([])
  useEffect(()=>{
    const getTasks = async() => {
      const tasksFromserver = await fetchTasks()
      setTasks(tasksFromserver)
    }
    getTasks()
  },[])
  //Fetch Tasks 
  const fetchTasks = async () =>{
    const res = await fetch('http://localhost:5000/tasks')
    const data = await res.json()

    console.log(data)
    return data
  }
  //Feth Task
  const fetchTask = async (id) =>{
    const res = await fetch(`http://localhost:5000/tasks/${id}`)
    const data = await res.json()

    console.log(data)
    return data
  }

  //ADd Task
  const addTask = async (task) =>{
    console.log(task)
    const res = await fetch('http://localhost:5000/tasks',{
      method:'POST',
      headers:{
        'Content-type':'application/json'
      },
      body:JSON.stringify(task)
    })
    const data = await res.json() //위에걸 진행
    setTasks([...tasks,data]) //tasks 에 data 추가 
    // const id = Math.floor(Math.random()*10000) +1 // 표면적인 것일 뿐 json저장안딤
    // console.log(id);
    // const newTask = {id,...task};
    // setTasks([...tasks, newTask]);
  }

  //Delete TAsk
  const deleteTask = async (id) =>{
    //json del
    await fetch(`http://localhost:5000/tasks/${id}`,{
      method: 'DELETE'
    })

    console.log('delete', id)
    setTasks(tasks.filter((task)=> task.id !== id))
  }
  //Reminder 
  const toggleReminder = async (id) => {
    console.log(id)
    const taskToToggle = await fetchTask(id)
    console.log('fetchTask id한 것에 대한 토글 : '+taskToToggle.reminder+':'+taskToToggle.text);
    const updTask = {...taskToToggle, reminder: !taskToToggle.reminder}
    const res = await fetch(`http://localhost:5000/tasks/${id}`,{
      method:'PUT',
      headers:{
        'Content-Type':'application/json'
      },
      body:JSON.stringify(updTask)
    })
    const data = await res.json()


    setTasks(tasks.map((task)=>task.id === id ? { ...task, reminder:!data.reminder }: task))
  }
  return (
    <Router>
    <div className='container'>
      <Header onAdd={()=> setShowAddTask(!showAddTask)} showAdd={showAddTask} />
      <Route path='/' exact render={(props) => (
        <>
          {showAddTask && <AddTask onAdd={addTask}/>}
      {tasks.length >0 ? <Tasks tasks={tasks} onDelete={deleteTask} onToggle={toggleReminder}/> : 'No Tasks to show'}
        </>
      )} />
      <Route path='/about' component={About} />
      <Footer />
    </div>
    </Router>
  )
}


export default App;
