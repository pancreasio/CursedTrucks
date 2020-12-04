using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PalletMover : ManejoPallets
{

    public GameObject firstStepUI;
    public GameObject secondStepUI;
    public GameObject thirdStepUI;

    public MoveType miInput;
    public enum MoveType {
        WASD,
        Arrows
    }

    public ManejoPallets Desde, Hasta;
    bool segundoCompleto = false;

    private void Start()
    {
        firstStepUI.SetActive(true);
        secondStepUI.SetActive(false);
        thirdStepUI.SetActive(false);
    }

    private void Update() {
        switch (miInput) {
            case MoveType.WASD:
                if (!Tenencia() && Desde.Tenencia() && Input.GetKeyDown(KeyCode.A)) {
                    PrimerPaso();
                }
                if (Tenencia() && Input.GetKeyDown(KeyCode.S)) {
                    SegundoPaso();
                }
                if (segundoCompleto && Tenencia() && Input.GetKeyDown(KeyCode.D)) {
                    TercerPaso();
                }
                break;
            case MoveType.Arrows:
                if (!Tenencia() && Desde.Tenencia() && Input.GetKeyDown(KeyCode.LeftArrow)) {
                    PrimerPaso();
                }
                if (Tenencia() && Input.GetKeyDown(KeyCode.DownArrow)) {
                    SegundoPaso();
                }
                if (segundoCompleto && Tenencia() && Input.GetKeyDown(KeyCode.RightArrow)) {
                    TercerPaso();
                }
                break;
            default:
                break;
        }
    }

    void PrimerPaso() {
        Desde.Dar(this);
        segundoCompleto = false;
    }
    void SegundoPaso() {
        base.Pallets[0].transform.position = transform.position;
        segundoCompleto = true;
    }
    void TercerPaso() {
        Dar(Hasta);
        segundoCompleto = false;
    }

    public void FirstStep()
    {
        if (!Tenencia() && Desde.Tenencia())
        {
            firstStepUI.SetActive(false);
            secondStepUI.SetActive(true);
            thirdStepUI.SetActive(false);
            PrimerPaso();
        }
    }

    public void SecondStep()
    {
        if (Tenencia())
        {
            firstStepUI.SetActive(false);
            secondStepUI.SetActive(false);
            thirdStepUI.SetActive(true);
            SegundoPaso();
        }
    }

    public void ThirdStep()
    {
        if (segundoCompleto && Tenencia())
        {
            firstStepUI.SetActive(true);
            secondStepUI.SetActive(false);
            thirdStepUI.SetActive(false);
            SegundoPaso();
            TercerPaso();
        }
    }

    public override void Dar(ManejoPallets receptor) {
        if (Tenencia()) {
            if (receptor.Recibir(Pallets[0])) {
                Pallets.RemoveAt(0);
            }
        }
    }
    public override bool Recibir(Pallet pallet) {
        if (!Tenencia()) {
            pallet.Portador = this.gameObject;
            base.Recibir(pallet);
            return true;
        }
        else
            return false;
    }
}
