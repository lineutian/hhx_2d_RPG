using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetManager : Singleton<GetManager>
{
    public T getitem<T>(T item)
    {
        T newB=item;
        return newB;
    }
}
