using UnityEngine;

[CreateAssetMenu(fileName = "NuevoPuntaje", menuName = "ScriptableObjects/Puntaje")]
public class PuntajeSO : ScriptableObject
{
    public int puntaje;
    public int puntajeMax;
    public NotificationData noti1;
    public NotificationData noti2;
    private NotificationData envio;
    public void ActualizarPuntaje(int puntajeObtenido)
    {
        if (puntajeObtenido > puntajeMax)
        {
            puntajeMax = puntajeObtenido;
            noti2.text = "NUEVO PUNTAJE MAXIMO: " + puntajeMax.ToString();
            puntaje = 0;
            NotificationSimple.Instance.SendNotification(noti2);
        }
        else
        {
            noti1.text = puntajeObtenido.ToString();
            NotificationSimple.Instance.SendNotification(noti1);
        }
    } 


}
